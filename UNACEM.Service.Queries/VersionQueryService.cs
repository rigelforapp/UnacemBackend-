using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Common.Collection;
using UNACEM.Common.Mapping;
using UNACEM.Common.Paging;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.DTO;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface IVersionQueryService
    {
        Task<VersionResponse> GetAll(int OvenId, int Start, int Limit);
        Task<VersionResponse> Create(VersionRequest versionRequest );
        Task<VersionResponse> Update(VersionRequest versionRequest );

    }

    public class VersionQueryService : IVersionQueryService
    {
        private readonly ApplicationDbContext _context;

        public VersionQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VersionResponse> Create(VersionRequest versionRequest)
        {
            VersionResponse result = new VersionResponse();

            try
            {
                Versions version = new Versions();

                version.OvenId = versionRequest.OvenId;
                version.Name = versionRequest.Name;
                version.DateIni =versionRequest.DateIni;
                version.DateEnd =versionRequest.DateEnd;
                await _context.AddAsync(version);
                await _context.SaveChangesAsync();

                foreach (var s in versionRequest.Stretchs)
                {
                    
                    // Create
                    var newS = new Stretchs();
                    newS.VersionId = version.Id;
                    newS.TextureId = s.TextureId;
                    newS.ColorId = s.ColorId;
                    newS.PositionIni = s.PositionIni;
                    newS.PositionEnd = s.PositionEnd;
                    newS.BrickFormatId = s.BrickFormatId;
                    newS.ProviderBrickId = s.ProviderBrickId;
                    newS.CreatedAt = DateTime.Now;

                    _context.Stretchs.Add(newS);
                }

                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<VersionResponse> GetAll(int OvenId, int Start, int Limit)
        {
            VersionResponse result = new VersionResponse();

            try
            {
                var collection = await _context.Versions.AsNoTracking().Where(a => a.OvenId == OvenId).OrderBy(x => x.OvenId).GetPagedAsync(Start, Limit);
                var versionresult = collection.MapTo<DataCollection<VersionDto>>();

                result.Success = true;
                result.Message = "Se realizó correctamente";
                result.Data = (List<VersionDto>)versionresult.Items;

                foreach (var item in result.Data)
                {
                    item.Stretchs = new List<Stretchs>();
                    item.Stretchs = _context.Stretchs.Where(s => s.VersionId == item.Id).OrderBy( s=> s.PositionIni ).ToList();

                    foreach (var stretch in item.Stretchs)
                    {
                        stretch.ProviderBricks = _context.ProviderBricks.Where(pb => pb.Id == stretch.ProviderBrickId).FirstOrDefault();                        
                        stretch.ProviderBricks.ProviderImportations = _context.ProviderImportations.Where(pi => pi.Id == stretch.ProviderBricks.ProviderImportationId).FirstOrDefault();
                        stretch.ProviderBricks.ProviderImportations.Providers = _context.Providers.Where(p => p.Id == stretch.ProviderBricks.ProviderImportations.ProviderId).FirstOrDefault();

                        stretch.BrickFormats = _context.BrickFormats.Where(pb => pb.Id == stretch.BrickFormatId).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al Consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<VersionResponse> Update(VersionRequest versionRequest)
        {
            VersionResponse result = new VersionResponse();

            try
            {
                var v = _context.Versions.Where(v => v.Id == versionRequest.Id).FirstOrDefault();

                if (v != null)
                {
                    v.OvenId = versionRequest.OvenId;
                    v.Name = versionRequest.Name;
                    v.DateIni = Convert.ToDateTime(versionRequest.DateIni);
                    v.DateEnd = Convert.ToDateTime(versionRequest.DateEnd);

                    _context.Versions.Update(v);

                    await _context.SaveChangesAsync();

                    var stretchs = _context.Stretchs.Where(s => s.VersionId == v.Id).ToList();
                    foreach (var s in stretchs)
                    {
                        s.DeletedAt = DateTime.Now;
                        _context.Stretchs.Update(s);
                    }

                    await _context.SaveChangesAsync();

                    if (versionRequest.Stretchs != null)
                    {
                        foreach (var s in versionRequest.Stretchs)
                        {
                            using (var transaction = _context.Database.BeginTransaction())
                            {
                                try
                                {
                                    var stretch = new Stretchs();

                                    if (s.Id != null)
                                    {
                                        stretch = _context.Stretchs.Where(stretch => stretch.Id == s.Id).FirstOrDefault();
                                        stretch.DeletedAt = null;
                                    }

                                    stretch.PositionIni = s.PositionIni;
                                    stretch.PositionEnd = s.PositionEnd;
                                    stretch.BrickFormatId = s.BrickFormatId;
                                    stretch.ProviderBrickId = s.ProviderBrickId;
                                    stretch.TextureId = s.TextureId;
                                    stretch.ColorId = s.ColorId;
                                    stretch.UpdatedAt = DateTime.Now;
                                    stretch.VersionId = v.Id;

                                    if (s.Id != null)
                                    {
                                        _context.Stretchs.Update(stretch);
                                    }
                                    else
                                    {
                                        stretch.CreatedAt = DateTime.Now;
                                        _context.Stretchs.Add(stretch);
                                    }

                                    await _context.SaveChangesAsync();

                                    transaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    throw ex;
                                }
                            }
                        }
                    }

                    result.Success = true;
                    result.Message = "Se realizó satisfactoriamente";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

    }
}

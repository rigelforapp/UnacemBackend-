using Microsoft.EntityFrameworkCore;
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

                version.OvenId = versionRequest.Oven_Id;
                version.Name = versionRequest.Name;
                version.Date_Ini = versionRequest.Date_Ini;
                version.Date_End = versionRequest.Date_End;

                await _context.AddAsync(version);
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
                    item.DateIni = item.Date_Ini.ToString("dd/MM/yyyy");
                    item.DateEnd = item.Date_End.ToString("dd/MM/yyyy");
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
                var versions = _context.Versions.Where(v => v.VersionId == versionRequest.Id).FirstOrDefault();

                if (versions != null)
                {
                    versions.OvenId = versionRequest.Oven_Id;
                    versions.Name = versionRequest.Name;
                    versions.Date_Ini = versionRequest.Date_Ini;
                    versions.Date_End = versionRequest.Date_End;

                    await _context.SaveChangesAsync();
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

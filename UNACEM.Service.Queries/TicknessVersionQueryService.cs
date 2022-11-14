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
    public interface ITicknessVersionQueryService
    {
        Task<TicknessVersionResponse> Create(TicknessVersionRequest ticknessVersionRequest);
        Task<TicknessVersionResponse> Update(TicknessVersionRequest ticknessVersionRequest);
        Task<TicknessVersionResponse> Delete(TicknessVersionRequest ticknessVersionRequest);
        Task<object> GetAll(int Start, int Limit, int TicknessId);
    }

    public class TicknessVersionQueryService : ITicknessVersionQueryService
    {
        private readonly ApplicationDbContext _context;

        public TicknessVersionQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TicknessVersionResponse> Create(TicknessVersionRequest tvRequest)
        {
            TicknessVersionResponse result = new TicknessVersionResponse();

            try
            {
                TicknessVersions tv = new TicknessVersions();
                tv.Name = tvRequest.Name;
                tv.TicknessId = tvRequest.TicknessId;

                await _context.AddAsync(tv);
                await _context.SaveChangesAsync();

                foreach (var rr in tvRequest.Registers)
                {
                    var r = new TicknessVersionRegisters();
                    r.TicknessVersionId = tv.Id;
                    r.Position = rr.Position;
                    r.Value = rr.Value;

                    await _context.AddAsync(r);
                }

                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Se realizo satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<TicknessVersionResponse> Delete(TicknessVersionRequest tvRequest)
        {
            TicknessVersionResponse result = new TicknessVersionResponse();

            try
            {
                var tv = _context.TicknessVersions.Where(tv => tv.Id == tvRequest.Id).FirstOrDefault();

                if (tv != null)
                {
                    tv.DeletedAt = DateTime.Now;

                    await _context.SaveChangesAsync();

                    result.Success = true;
                    result.Message = "Se realizo satisfactoriamente";

                }
                else
                {
                    result.Success = false;
                    result.Message = "No se encontro datos";
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

        public async Task<object> GetAll(int Start, int Limit, int TicknessId)
        {
            TicknessVersionResponse result = new TicknessVersionResponse();

            try
            {
                var versions = _context.TicknessVersions.Where( tv => tv.TicknessId == TicknessId ).AsNoTracking().OrderBy(x => x.Id).ToList();
                List<TicknessVersionDto> data = new List<TicknessVersionDto>();

                foreach (var v in versions)
                {
                    TicknessVersionDto vDto = new TicknessVersionDto();
                    vDto.Id = v.Id;
                    vDto.Name = v.Name;


                    var registers = _context.TicknessVersionRegisters.Where(x => x.TicknessVersionId == v.Id && x.DeletedAt == null).ToList();
                    vDto.Registers = registers;
                    data.Add(vDto);
                }

                result.Success = true;
                result.Message = "Se realizo correctamente";
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<TicknessVersionResponse> Update(TicknessVersionRequest tvRequest)
        {
            TicknessVersionResponse result = new TicknessVersionResponse();

            try
            {
                var tv = _context.TicknessVersions.Where(tv => tv.Id == tvRequest.Id).FirstOrDefault();

                if (tv != null)
                {

                    tv.Name = tvRequest.Name;

                    var tvrs = _context.TicknessVersionRegisters.Where(x => x.TicknessVersionId == tv.Id && x.DeletedAt == null).ToList();

                    foreach (var tvr in tvrs)
                    {
                        tvr.DeletedAt = DateTime.Now;
                        _context.TicknessVersionRegisters.Update(tvr);
                    }

                    await _context.SaveChangesAsync();

                    foreach (var tvrr in tvRequest.Registers)
                    {
                        var tvr = new TicknessVersionRegisters();

                        if (tvrr.Id > 0)
                        {
                            tvr = _context.TicknessVersionRegisters.Where(tvr => tvr.Id == tvrr.Id).FirstOrDefault();
                            tvr.DeletedAt = null;
                        }

                        tvr.Position = tvrr.Position;
                        tvr.Value = tvrr.Value;
                        tvr.TicknessVersionId = tvRequest.Id;

                        if (tvrr.Id > 0)
                        {
                            _context.TicknessVersionRegisters.Update(tvr);
                        }
                        else
                        {
                            _context.TicknessVersionRegisters.Add(tvr);
                        }
                    }

                    await _context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Se realizo satistactoriamente";
                }
                else
                {
                    result.Success = false;
                    result.Message = "No se encontro datos";
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

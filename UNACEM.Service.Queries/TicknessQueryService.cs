using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Common.Collection;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.DTO;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface ITicknessQueryService
    {
        Task<TicknessResponse> Create(TicknessRequest ticknessRequest, Users user);
        Task<TicknessResponse> Update(TicknessRequest ticknessRequest, Users user);
        Task<TicknessResponse> Delete(TicknessRequest ticknessRequest, Users user);
        Task<object> GetAll(int Start, int Limit, Users user);
    }

    public class TicknessQueryService : ITicknessQueryService
    {
        private readonly ApplicationDbContext _context;

        public TicknessQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TicknessResponse> Create(TicknessRequest ticknessRequest, Users user)
        {
            TicknessResponse result = new TicknessResponse();

            try
            {
                Tickness t = new Tickness();
                t.Name = ticknessRequest.Name;
                t.Height = ticknessRequest.Height;
                t.Width = ticknessRequest.Width;
                t.UserId = user.Id;

                await _context.AddAsync(t);

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

        public async Task<TicknessResponse> Delete(TicknessRequest ticknessRequest, Users user)
        {
            TicknessResponse result = new TicknessResponse();

            try
            {
                var budgetCi = _context.BudgetsCi.Where(b => b.Id == ticknessRequest.Id).FirstOrDefault();

                if (budgetCi != null)
                {
                    budgetCi.DeletedAt = DateTime.Now;

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

        public async Task<object> GetAll(int Start, int Limit, Users user)
        {
            TicknessResponse result = new TicknessResponse();

            try
            {
                var ticknesses = _context.Tickness.Where( t => t.DeletedAt == null ).Where(t=>t.UserId==user.Id).OrderBy(x => x.Id).ToList();
                List<TicknessDto> data = new List<TicknessDto>();

                foreach (var t in ticknesses)
                {
                    TicknessDto tDto = new TicknessDto();
                    tDto.Id = t.Id;
                    tDto.Name = t.Name;
                    tDto.Width = t.Width;
                    tDto.Height = t.Height;
                    tDto.CreatedAt = t.CreatedAt;
                    tDto.UpdatedAt = t.UpdatedAt;

                    data.Add(tDto);
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

        public async Task<TicknessResponse> Update(TicknessRequest ticknessRequest, Users user)
        {
            TicknessResponse result = new TicknessResponse();

            try
            {
                var t = _context.Tickness.Where(b => b.Id == ticknessRequest.Id).FirstOrDefault();

                if (t != null)
                {
                    if (ticknessRequest.deleted==true)
                    {
                        t.DeletedAt = DateTime.Now;
                    }

                    t.Name = ticknessRequest.Name;
                    t.Height = ticknessRequest.Height;
                    t.Width = ticknessRequest.Width;

                    _context.Tickness.Update(t);

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

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Common.Collection;
using UNACEM.Common.Mapping;
using UNACEM.Common.Paging;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.DTO;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface IFormatsQueryService
    {
        Task<BrickFormatsResponse> GetAll(int Start, int Limit, int Diameter);
       
    }
    public class FormatsQueryService : IFormatsQueryService
    {
        private readonly ApplicationDbContext _context;
        public FormatsQueryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BrickFormatsResponse> GetAll(int Start, int Limit, int Diameter)
        {
            var result = new BrickFormatsResponse();
            try
            {
                var collection = await _context.BrickFormats.AsNoTracking().Where(a=>a.Diameter== Diameter).OrderByDescending(x => x.BrickFormatId).GetPagedAsync(Start, Limit);
                var providersresult = collection.MapTo<DataCollection<ProvidersDto>>();

                result.Success = true;
                result.Message = "Se realizo satisfactoriamente";
                result.Data = (List<BrickFormatsDto>)providersresult.Items;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }
    }
}

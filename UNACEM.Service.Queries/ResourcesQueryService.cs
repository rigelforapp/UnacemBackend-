using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface IResourcesQueryService
    {
        Task<ResourcesResponse> GetAll(string type);
    }

    public class ResourcesQueryService : IResourcesQueryService
    {
        private readonly ApplicationDbContext _context;

        public ResourcesQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResourcesResponse> GetAll(string type)
        {
            ResourcesResponse result = new ResourcesResponse();
          
            try
            {
             
                if (type.ToUpper() == "brick".ToUpper())
                {

                    var collection = _context.ProviderBricks.Where(x => x.CreatedAt != null).Cast<object>().ToList();
                 
                    result.Data = collection;
                }
                else if (type.ToUpper() == "insulating".ToUpper())
                {
                    var collection = _context.ProviderInsulatings.Where(x => x.CreatedAt != null).Cast<object>().ToList();
                    result.Data = collection;

                }
                else if (type.ToUpper() == "concrete".ToUpper())
                {
                    var collection = _context.ProviderConcretes.Where(x => x.CreatedAt != null).Cast<object>().ToList();


                    result.Data = collection;
                }
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
    }
}

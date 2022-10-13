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
        Task<ResourcesResponse> GetAll(string Type, int ProviderId);
    }

    public class ResourcesQueryService : IResourcesQueryService
    {
        private readonly ApplicationDbContext _context;

        public ResourcesQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResourcesResponse> GetAll(string Type, int ProviderId)
        {
            ResourcesResponse result = new ResourcesResponse();
          
            try
            {
             
                if (Type.ToUpper() == "brick".ToUpper())
                {
                    var providerBricks = (from ProviderBricks in _context.Set<ProviderBricks>()
                                join ProviderImportations in _context.Set<ProviderImportations>()
                                    on ProviderBricks.ProviderImportationId equals ProviderImportations.Id
                                join Providers in _context.Set<Providers>()
                                    on ProviderImportations.ProviderId equals Providers.Id
                                where(Providers.Id == ProviderId)
                                select ProviderBricks ).ToList<Object>();

                    //var collection = _context.ProviderBricks.Where(x => x.DeletedAt != null).Cast<object>().ToList();
                 
                    result.Data = providerBricks;
                }
                else if (Type.ToUpper() == "insulating".ToUpper())
                {
                    var collection = _context.ProviderInsulatings.Where(x => x.DeletedAt != null).Cast<object>().ToList();
                    result.Data = collection;

                }
                else if (Type.ToUpper() == "concrete".ToUpper())
                {
                    var collection = _context.ProviderConcretes.Where(x => x.DeletedAt != null).Cast<object>().ToList();


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

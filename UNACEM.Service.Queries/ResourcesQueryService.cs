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
                                where(Providers.Id == ProviderId) where (ProviderBricks.DeletedAt == null)
                                select ProviderBricks ).ToList<Object>();
                 
                    result.Data = providerBricks;
                }
                else if (Type.ToUpper() == "insulating".ToUpper())
                {
                    var list = (from ProviderInsulatings in _context.Set<ProviderInsulatings>()
                                               join ProviderImportations in _context.Set<ProviderImportations>()
                                                   on ProviderInsulatings.ProviderImportationId equals ProviderImportations.Id
                                               join Providers in _context.Set<Providers>()
                                                   on ProviderImportations.ProviderId equals Providers.Id
                                               where (Providers.Id == ProviderId)
                                               where (ProviderInsulatings.DeletedAt == null)
                                               select ProviderInsulatings).ToList<Object>();

                    result.Data = list;

                }
                else if (Type.ToUpper() == "concrete".ToUpper())
                {
                    var list = (from ProviderConcretes in _context.Set<ProviderConcretes>()
                                               join ProviderImportations in _context.Set<ProviderImportations>()
                                                   on ProviderConcretes.ProviderImportationId equals ProviderImportations.Id
                                               join Providers in _context.Set<Providers>()
                                                   on ProviderImportations.ProviderId equals Providers.Id
                                               where (Providers.Id == ProviderId)
                                               where (ProviderConcretes.DeletedAt == null)
                                               select ProviderConcretes).ToList<Object>();

                    result.Data = list;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("budgetCI/Resources")]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourcesQueryService _resourcesQueryService;

        public ResourcesController(IResourcesQueryService resourcesQueryService)
        {
            _resourcesQueryService = resourcesQueryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string Type, int ProviderId)
        {
           var  response = await _resourcesQueryService.GetAll(Type, ProviderId );
            return Ok(response);
        }

    }
}
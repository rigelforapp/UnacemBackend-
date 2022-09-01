using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("Ovens/Versions/Stretchs")]
    public class StretchsController : ControllerBase
    {
        private readonly IStretchsQueryService _stretchsQueryService;

        public StretchsController(IStretchsQueryService stretchsQueryService)
        {
            _stretchsQueryService = stretchsQueryService;
        }

        [HttpPost]
        public async Task<StretchsResponse> Create(StretchsRequest stretchsRequest)
        {
            return await _stretchsQueryService.Create(stretchsRequest);
        }

        [HttpGet]
        public async Task<StretchsResponse> GetAll(int VersionId, int Start, int Limit)
        {
            return await _stretchsQueryService.GetAll(VersionId, Start, Limit);
        }

        [HttpPut]
        public async Task<StretchsResponse> Update(StretchsRequest stretchsRequest)
        {
            return await _stretchsQueryService.Update(stretchsRequest);
        }
    }
}

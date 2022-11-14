using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.API.Authorization;
using UNACEM.Common.Configuration;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("ovens/versions/stretchs")]
    [Auth]
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
        public async Task<StretchsResponse> GetAll(int versionId, int start = Manager.VariableGlobal.Numero.Uno, int limit = Manager.VariableGlobal.Numero.Diez)
        {
            return await _stretchsQueryService.GetAll(versionId, start, limit);
        }

        [HttpPut]
        public async Task<StretchsResponse> Update(StretchsRequest stretchsRequest)
        {
            return await _stretchsQueryService.Update(stretchsRequest);
        }
    }
}

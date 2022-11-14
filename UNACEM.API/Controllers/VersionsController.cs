using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.API.Authorization;
using UNACEM.Common.Configuration;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("ovens/versions")]
    [Auth]
    public class VersionsController : ControllerBase
    {
        private readonly IVersionQueryService _versionQueryService;

        public VersionsController(IVersionQueryService versionQueryService)
        {
            _versionQueryService = versionQueryService;
        }

        [HttpPost]
        public async Task<VersionResponse> Create(VersionRequest versionRequest)
        {
            return await _versionQueryService.Create(versionRequest);
        }

        [HttpGet]
        public async Task<VersionResponse> GetAll(int ovenId, int start = Manager.VariableGlobal.Numero.Uno, int limit = Manager.VariableGlobal.Numero.Diez)
        {
            return await _versionQueryService.GetAll(ovenId, start, limit);
        }

        [HttpPut]
        public async Task<VersionResponse> Update(VersionRequest versionRequest)
        {
            return await _versionQueryService.Update(versionRequest);
        }
    }
}

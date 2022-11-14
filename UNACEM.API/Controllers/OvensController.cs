using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.API.Authorization;
using UNACEM.Common.Configuration;
using UNACEM.Domain;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    [Route("ovens")]
    [Auth]
    public class OvensController : ControllerBase
    {
        private readonly IOvensQueryService _ovensQueryService;

        public OvensController(IOvensQueryService ovensQueryService)
        {
            _ovensQueryService = ovensQueryService;
        }

        [HttpPost]
        public async Task<OvensResponse> Create(OvensRequest ovensRequest)
        {
            return await _ovensQueryService.Create(ovensRequest, (Users)HttpContext.Items["User"]);
        }

        [HttpPut]
        public async Task<OvensResponse> Update(OvensRequest ovensRequest)
        {
            return await _ovensQueryService.Update(ovensRequest, (Users)HttpContext.Items["User"]);
        }

        [HttpGet]
        public async Task<OvensResponse> GetAll(int start = Manager.VariableGlobal.Numero.Uno, int limit = Manager.VariableGlobal.Numero.Diez)
        {
            return await _ovensQueryService.GetAll(start, limit, (Users)HttpContext.Items["User"]);
        }
    }
}

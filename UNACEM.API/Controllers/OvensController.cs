using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    [Route("Ovens")]
    public class OvensController : ControllerBase
    {
        private readonly IOvensQueryService _ovensQueryService;

        public OvensController(IOvensQueryService ovensQueryService)
        {
            _ovensQueryService = ovensQueryService;
        }

        [HttpPost("Create")]
        public async Task<OvensResponse> Create(OvensRequest ovensRequest)
        {
            return await _ovensQueryService.Create(ovensRequest);
        }

        [HttpPut("Update")]
        public async Task<OvensResponse> Update(OvensRequest ovensRequest)
        {
            return await _ovensQueryService.Update(ovensRequest);
        }

        [HttpGet("GetAll")]
        public async Task<OvensResponse> GetAll(int Start, int Limit)
        {
            return await _ovensQueryService.GetAll(Start, Limit);
        }
    }
}

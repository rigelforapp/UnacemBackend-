using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("Formats")]
    public class FormatsController : ControllerBase
    {
        private readonly IFormatsQueryService _formatsQueryService;

        public FormatsController(IFormatsQueryService formatsQueryService)
        {
            _formatsQueryService = formatsQueryService;
        }
        [HttpGet("GetAll")]

        public async Task<BrickFormatsResponse> GetAllFormats(int Start, int Limit,int Diameter)
        {
            return await _formatsQueryService.GetAll(Start, Limit, Diameter);
        }
    }
}

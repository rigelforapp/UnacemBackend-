using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("{entity}")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProvidersQueryService _providersQueryService;

        public ProvidersController(IProvidersQueryService providersQueryService)
        {
            _providersQueryService = providersQueryService;
        }
        [HttpPost("Create")]
        public async Task<ProvidersResponse> Create(ProvidersRequest providersRequest)
        {
            return await _providersQueryService.Create(providersRequest);
        }
        [HttpPut("Update")]
        public async Task<ProvidersResponse> Update(ProvidersRequest providersRequest)
        {
            return await _providersQueryService.Update(providersRequest);
        }

        [HttpGet]
        public async Task<ProvidersResponse> GetAll(int Start, int Limit)
        {
            return await _providersQueryService.GetAll(Start, Limit);
        }

        [HttpPost("UploadFile")]
        public async Task<ProvidersResponse> UploadFile([FromForm] ProvidersRequest providersRequest,IFormFile file )
        {
            var ProvidersResponse = new ProvidersResponse();
            //var files = file;
            if (file!=null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    Stream stream = new MemoryStream(fileBytes);
                    ProvidersResponse = await _providersQueryService.Upload(stream, providersRequest);

                }

            }
        

            return ProvidersResponse;
        }
    }
}

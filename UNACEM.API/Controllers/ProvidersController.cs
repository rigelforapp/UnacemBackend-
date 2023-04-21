using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    [ApiController]
    [Route("providers")]
    [Auth]
    public class ProvidersController : ControllerBase
    {
        private readonly IProvidersQueryService _providersQueryService;

        public ProvidersController(IProvidersQueryService providersQueryService)
        {
            _providersQueryService = providersQueryService;
        }
        [HttpPost]
        public async Task<ProvidersResponse> Create(ProvidersRequest providersRequest)
        {
            return await _providersQueryService.Create(providersRequest);
        }
        [HttpPut]
        public async Task<ProvidersResponse> Update(ProvidersRequest providersRequest)
        {
            return await _providersQueryService.Update(providersRequest, (Users)HttpContext.Items["User"]);
        }

        [HttpGet]
        public async Task<ProvidersResponse> GetAll(int start = Manager.VariableGlobal.Numero.Uno, int limit = Manager.VariableGlobal.Numero.Diez)
        {
            return await _providersQueryService.GetAll(start, limit);
        }

        [HttpPost("upload-file")]
        public async Task<ProvidersResponse> UploadFile([FromForm] int providerId,IFormFile file )
        {
            var ProvidersResponse = new ProvidersResponse();
            //var files = file;
            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    Stream stream = new MemoryStream(fileBytes);
                    ProvidersResponse = await _providersQueryService.Upload(stream, providerId, (Users)HttpContext.Items["User"]);
                }
            }

            return ProvidersResponse;
        }
    }
}

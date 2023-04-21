using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.API.Authorization;
using UNACEM.Common.Configuration;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]// ApiController
    [Route("formats")]
    
    public class FormatsController : ControllerBase
    {
        private readonly IFormatsQueryService _formatsQueryService;

        public FormatsController(IFormatsQueryService formatsQueryService)
        {
            _formatsQueryService = formatsQueryService;
        }

        [HttpGet]
        [Auth]
        public async Task<BrickFormatsResponse> GetAllFormats(int diameter = 0, int start = Manager.VariableGlobal.Numero.Uno, int limit = Manager.VariableGlobal.Numero.Diez)
        {
            return await _formatsQueryService.GetAll(diameter, start, limit);
        }

        [HttpPost("upload-file")]
        [AllowAnonymous]
        public async Task<BrickFormatsResponse> UploadFile(IFormFile File)
        {
            var ProvidersResponse = new BrickFormatsResponse();
            //var files = file;
            if (File != null)
            {
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    Stream stream = new MemoryStream(fileBytes);
                    ProvidersResponse = await _formatsQueryService.Upload(stream);
                }
            }

            return ProvidersResponse;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Common.Configuration;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]// ApiController
    [Route("Formats")]
    public class FormatsController : ControllerBase
    {
        private readonly IFormatsQueryService _formatsQueryService;

        public FormatsController(IFormatsQueryService formatsQueryService)
        {
            _formatsQueryService = formatsQueryService;
        }

        [HttpGet]
        public async Task<BrickFormatsResponse> GetAllFormats(int Diameter, int Start = Manager.VariableGlobal.Numero.Uno, int Limit = Manager.VariableGlobal.Numero.Diez)
        {
            return await _formatsQueryService.GetAll(Diameter, Start, Limit);
        }

        [HttpPost("UploadFile")]
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

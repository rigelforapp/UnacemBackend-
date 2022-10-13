using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UNACEM.Common.Configuration;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("Gallery")]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryQueryService _galleryQueryService;

        public GalleryController(IGalleryQueryService galleryQueryService)
        {
            _galleryQueryService = galleryQueryService;
        }

        [HttpPost]
        public async Task<GalleryResponse> Create([FromForm] GalleryRequest galleryRequest, IFormFile file)
        {
            byte[] bufferfoto;

            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    Stream stream = new MemoryStream(fileBytes);
                    BinaryReader lector = new BinaryReader(stream);
                    bufferfoto = lector.ReadBytes((int)file.Length);
                    galleryRequest.Image = bufferfoto;
                    galleryRequest.Type = file.ContentType;
                    galleryRequest.Name = file.FileName;
                }

            }
            return await _galleryQueryService.Create(galleryRequest);
        }

        [HttpGet]
        public async Task<GalleryResponse> GetAll(int versionId, int start = Manager.VariableGlobal.Numero.Uno, int limit = Manager.VariableGlobal.Numero.Diez)
        {
            return await _galleryQueryService.GetAll(versionId, start, limit);
        }

        [HttpPut]
        public async Task<GalleryResponse> Update([FromForm] GalleryRequest galleryRequest, IFormFile File)
        {
            byte[] bufferfoto;

            if (File != null)
            {
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    Stream stream = new MemoryStream(fileBytes);
                    BinaryReader lector = new BinaryReader(stream);
                    bufferfoto = lector.ReadBytes((int)File.Length);
                    galleryRequest.Image = bufferfoto;
                    galleryRequest.Type = File.ContentType;
                    galleryRequest.Name = File.FileName;
                }

            }

            return await _galleryQueryService.Update(galleryRequest);
        }
    }
}

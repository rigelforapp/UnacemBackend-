using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Common.Collection;
using UNACEM.Common.Mapping;
using UNACEM.Common.Paging;
using UNACEM.Domain;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.DTO;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.Service.Queries
{
    public interface IGalleryQueryService
    {
        Task<GalleryResponse> Create(GalleryRequest galleryRequest);
        Task<GalleryResponse> Update(GalleryRequest galleryRequest);
        Task<GalleryResponse> GetAll(int VersionId, int Start, int Limit);
    }

    public class GalleryQueryService : IGalleryQueryService
    {
        private readonly ApplicationDbContext _context;
        public GalleryQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GalleryResponse> Create(GalleryRequest galleryRequest)
        {
            GalleryResponse result = new GalleryResponse();

            try
            {
                await _context.AddAsync(new Gallery() 
                {
                    VersionId = galleryRequest.VersionId,
                    Type = galleryRequest.Type,
                    Name = galleryRequest.Name,
                    Title = galleryRequest.Title,
                    Image = galleryRequest.Image,
                    Description = galleryRequest.Description
                
                });

                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<GalleryResponse> GetAll(int VersionId, int Start, int Limit)
        {
            GalleryResponse result = new GalleryResponse();

            try
            {
                var collection = await _context.Gallery.AsNoTracking().Where(g => g.VersionId == VersionId).OrderBy(x => x.VersionId).GetPagedAsync(Start, Limit);
                var galleryresult = collection.MapTo<DataCollection<GalleryDto>>();

                result.Success = true;
                result.Message = "Se realizó satisfactoriamente";
                result.Data = (List<GalleryDto>)galleryresult.Items;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al consultar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }

        public async Task<GalleryResponse> Update(GalleryRequest galleryRequest)
        {
            GalleryResponse result = new GalleryResponse();

            try
            {
                var gallery = _context.Gallery.Where(g => g.Id == galleryRequest.Id).FirstOrDefault();

                if(gallery != null)
                {
                    gallery.VersionId = galleryRequest.VersionId;
                    gallery.Type = galleryRequest.Type;
                    gallery.Name = galleryRequest.Name;
                    gallery.Title = galleryRequest.Title;
                    gallery.Image = galleryRequest.Image;
                    gallery.Description = galleryRequest.Description;

                    await _context.SaveChangesAsync();
                    result.Success = true;
                    result.Message = "Se realizó satisfactoriamente";
                }
                else
                {
                    result.Success = false;
                    result.Message = "No se encontro datos";
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al ejecutar";
                result.Details = ex.Message + " || " + ex.StackTrace;
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class GalleryDto
    {
        public int GalleryId { get; set; }
        public int VersionId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}

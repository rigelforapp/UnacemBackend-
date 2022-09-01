using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Gallery : AuditFields, IAuditFields
    {
        public int GalleryId { get; set; }
        public int VersionId { get; set; }
        [ForeignKey("VersionId")]
        public virtual Versions Versions { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}

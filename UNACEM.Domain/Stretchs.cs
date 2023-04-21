using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;
namespace UNACEM.Domain
{
    public class Stretchs : AuditFields, IAuditFields
    {
        public int? Id { get; set; }
        public int VersionId { get; set; }
        [ForeignKey("VersionId")]
        public virtual Versions Versions { get; set; }
        public int ProviderBrickId { get; set; }

        [ForeignKey("ProviderBrickId")]
        public virtual ProviderBricks ProviderBricks { get; set; }
        public int BrickFormatId { get; set; }

        [ForeignKey("BrickFormatId")]
        public virtual BrickFormats BrickFormats { get; set; }

        public double PositionIni { get; set; }
        public double PositionEnd { get; set; }
        public int ColorId { get; set; }
        public int TextureId { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;
namespace UNACEM.Domain
{
    public class Stretchs : AuditFields, IAuditFields
    {
        public int StretchId { get; set; }
        public int VersionId { get; set; }
        [ForeignKey("VersionId")]
        public virtual Versions Versions { get; set; }
        public int ProviderBrickId { get; set; }

        [ForeignKey("ProviderBrickId")]
        public virtual ProviderBricks ProviderBricks { get; set; }
        public int BrickFormatId { get; set; }

        [ForeignKey("BrickFormatId")]
        public virtual BrickFormats BrickFormats { get; set; }

        public double Position_Ini { get; set; }
        public double Position_End { get; set; }
        public int Color_Id { get; set; }
        public int Texture_Id { get; set; }
    }
}

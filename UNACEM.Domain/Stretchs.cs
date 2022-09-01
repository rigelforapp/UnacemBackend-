using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;
namespace UNACEM.Domain
{
    public class Stretchs : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int Version_Id { get; set; }
        [ForeignKey("Version_Id")]
        public virtual Versions Versions { get; set; }
        public int ProviderBrick_Id { get; set; }

        [ForeignKey("ProviderBrick_Id")]
        public virtual ProviderBricks ProviderBricks { get; set; }
        public int BrickFormat_Id { get; set; }

        [ForeignKey("BrickFormat_Id")]
        public virtual BrickFormats BrickFormats { get; set; }

        public double Position_Ini { get; set; }
        public double Position_End { get; set; }
        public int Color_Id { get; set; }
        public int Texture_Id { get; set; }
    }
}

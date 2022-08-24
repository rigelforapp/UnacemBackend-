using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Tyres : AuditFields, IAuditFields
    {
        public int TyreId { get; set; }

        public int OvenId { get; set; }
        [ForeignKey("OvenId")]
        public virtual Ovens Ovens { get; set; }
        public int ColorId { get; set; }

        [ForeignKey("ColorId")] 
        public virtual Color Color { get; set; }
        public int TextureId { get; set; }
        public int Position { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Tyres : AuditFields, IAuditFields
    {
        public int Id { get; set; }

        public int Oven_Id { get; set; }
        [ForeignKey("Oven_Id")]
        public virtual Ovens Ovens { get; set; }

        public int Color_Id { get; set; }
        [ForeignKey("Color_Id")] 
        public virtual Color Color { get; set; }

        public int Texture_Id { get; set; }

       // [Column(TypeName = "decimal(5, 2)")]
        public double Position { get; set; }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;
namespace UNACEM.Domain
{
    public class Ovens : AuditFields, IAuditFields
    {
        public int Id { get; set; }

        public int Headquarter_Id { get; set; }
        [ForeignKey("Headquarter_Id")]
        public virtual Headquarters Headquarters { get; set; }

        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual Users Users { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Large { get; set; }
        public int Diameter { get; set; }
    }
}

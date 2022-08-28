using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;
namespace UNACEM.Domain
{
    public class Ovens : AuditFields, IAuditFields
    {
        public int OvenId { get; set; }

        public int HeadquarterId { get; set; }
        [ForeignKey("HeadquarterId")]
        public virtual Headquarters Headquarters { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
        public string Name { get; set; }
        public int Large { get; set; }
        public int Diameter { get; set; }
    }
}

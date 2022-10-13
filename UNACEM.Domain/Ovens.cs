using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;
namespace UNACEM.Domain
{
    public class Ovens : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public string Headquarter { get; set; }
        public string Name { get; set; }
        public int Large { get; set; }
        public int Diameter { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        
    }
}

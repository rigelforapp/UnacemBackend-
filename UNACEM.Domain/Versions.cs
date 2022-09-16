
using System;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Versions : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int? OvenId { get; set; }
        [ForeignKey("OvenId")]
        public virtual Ovens Ovens { get; set; }
        public string Name { get; set; }
        public DateTime DateIni { get; set; }
        public DateTime DateEnd { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Versions : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int Oven_Id { get; set; }
        [ForeignKey("Oven_Id")]
        public virtual Ovens Ovens { get; set; }
        public string Name { get; set; }
        public DateTime Date_Ini { get; set; }
        public DateTime Date_End { get; set; }
    }
}

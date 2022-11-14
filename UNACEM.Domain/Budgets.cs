using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Budgets : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int OvenLarge { get; set; }
        public int OvenDiameter { get; set; }
        public double TotalAmount { get; set; }
        public int UserId { get; set; }
     
    }
}

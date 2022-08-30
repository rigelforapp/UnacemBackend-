using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Budgets : AuditFields, IAuditFields
    {
        public int BudgetId { get; set; }
        public int VersionId { get; set; }
        [ForeignKey("VersionId")]
        public virtual Versions Versions { get; set; }
        public double Total_Amount { get; set; }
     
    }
}

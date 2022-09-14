using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BudgetCiRows : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        
        public int BudgetCiId { get; set; }
        [ForeignKey("BudgetCiId")]
        public virtual BudgetsCi BudgetsCi { get; set; }
        
        public string Zone { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Area { get; set; }
        public double ThicknessC { get; set; }
        public double ThicknessI { get; set; }

        public int? ProviderInsulatingId { get; set; }
        [ForeignKey("ProviderInsulatingId")]
        public virtual ProviderInsulatings ProviderInsulatings { get; set; }

        public int? ProviderConcretesId { get; set; }
        [ForeignKey("ProviderConcretesId")]
        public virtual ProviderConcretes ProviderConcretes { get; set; }

        public double CostC { get; set; }
        public double CostI { get; set; }
        public double Total { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BudgetCICurrency : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int BudgetCIId { get; set; }
        [ForeignKey("BudgetCIId")]
        public virtual BudgetsCi BudgetsCi { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Equivalence { get; set; }
    }
}

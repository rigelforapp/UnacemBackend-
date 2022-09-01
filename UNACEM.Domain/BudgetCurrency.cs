using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BudgetCurrency : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int Budget_Id { get; set; }

        [ForeignKey("Budget_Id")]
        public virtual Budgets Budgets { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Equivalence { get; set; }
    }
}

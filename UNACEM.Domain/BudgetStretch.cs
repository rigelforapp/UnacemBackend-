using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BudgetStretch : AuditFields, IAuditFields
    {
        public int BudgetStretchId { get; set; }
        public int BudgetId { get; set; }
        [ForeignKey("BudgetId")]
        public virtual Budgets Budgets { get; set; }

        public int? StretchId { get; set; }
        [ForeignKey("StretchId")]
        public virtual Stretchs Stretchs { get; set; }

        public int? BrickFormatId { get; set; }
        [ForeignKey("BrickFormatId")]
        public virtual BrickFormats BrickFormats { get; set; }

        public double Brick_a_Cost { get; set; }
        public double Brick_b_Cost { get; set; }
        public double Wedge_a_Quantity { get; set; }
        public double Wedge_b_Quantity { get; set; }
        public double Wedge_a_Cost { get; set; }
        public double Wedge_b_Cost { get; set; }
        public double Total_Amount { get; set; }
    }
}

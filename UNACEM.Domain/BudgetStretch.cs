using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BudgetStretch : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int Budget_Id { get; set; }
        [ForeignKey("Budget_Id")]
        public virtual Budgets Budgets { get; set; }

        public int? Stretch_Id { get; set; }
        [ForeignKey("Stretch_Id")]
        public virtual Stretchs Stretchs { get; set; }

        public int? BrickFormat_Id { get; set; }
        [ForeignKey("BrickFormat_Id")]
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

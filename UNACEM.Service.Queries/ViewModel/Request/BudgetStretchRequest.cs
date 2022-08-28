using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class BudgetStretchRequest
    {
        public int BudgetStretchId { get; set; }
        public int? StretchId { get; set; }
        public int? BrickFormatId { get; set; }
        public double Brick_a_Cost { get; set; }
        public double Brick_b_Cost { get; set; }
        public double Wedge_a_Quantity { get; set; }
        public double Wedge_b_Quantity { get; set; }
        public double Wedge_a_Cost { get; set; }
        public double Wedge_b_Cost { get; set; }
        public double Total_Amount { get; set; }
    }
}

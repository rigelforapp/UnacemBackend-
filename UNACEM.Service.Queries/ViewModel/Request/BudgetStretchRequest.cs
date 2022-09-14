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
        public int Id { get; set; }
        public int? StretchId { get; set; }
        public int? BrickFormatId { get; set; }
        public double BrickACost { get; set; }
        public double BrickBCost { get; set; }
        public double WedgeAQuantity { get; set; }
        public double WedgeBQuantity { get; set; }
        public double WedgeACost { get; set; }
        public double WedgeBCost { get; set; }
        public double TotalAmount { get; set; }
    }
}

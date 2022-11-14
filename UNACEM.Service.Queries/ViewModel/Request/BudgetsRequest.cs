using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class BudgetsRequest
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public List<BudgetStretchRequest> budgetStretches { get; set; }
        public int OvenLarge { get; set; }
        public int OvenDiameter { get; set; }
        public string Description { get; set; }
        public bool? deleted { get; set; }
        public List<CurrencyRequest> currencies { get; set; }
    }
}
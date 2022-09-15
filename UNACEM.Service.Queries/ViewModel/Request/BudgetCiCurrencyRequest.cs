using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class BudgetCiCurrencyRequest
    {
        public int Id { get; set; }
        public int BudgetCiId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Equivalence { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class BudgetCiRequest
    {
        public int Id { get; set; }
        public string Line { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public double? Total { get; set; }
    }
}

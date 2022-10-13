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
        public int VersionId { get; set; }
        public double TotalAmount { get; set; }
        public List<BudgetStretchRequest> budgetStretchs { get; set; }
    }
}
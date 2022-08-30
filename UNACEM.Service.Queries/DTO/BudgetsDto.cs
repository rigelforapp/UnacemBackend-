using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.DTO
{
    public class BudgetsDto
    {
        public int BugetId { get; set; }
        public int VersionId { get; set; }
        public double Total_Amount { get; set; }
    }
}

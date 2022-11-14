using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;

namespace UNACEM.Service.Queries.DTO
{
    public class BudgetsStrechesDTO : BudgetStretch
    {
        public int ProviderId { get; set; } 
        public List<ProviderBricks> Bricks { get; set; }
    }
}

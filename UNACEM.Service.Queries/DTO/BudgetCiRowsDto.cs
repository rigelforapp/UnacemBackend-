using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;

namespace UNACEM.Service.Queries.DTO
{
    public class BudgetCiRowsDto
    {
        public int Id { get; set; }
        public int BudgetCiId { get; set; }
        public string Zone { get; set; }
        public decimal Area { get; set; }
        public double ThicknessC { get; set; }
        public double ThicknessI { get; set; }
        public int? ProviderInsulatingId { get; set; }
        public int? ProviderConcretesId { get; set; }
        public double CostC { get; set; }
        public double CostI { get; set; }
        public double Total { get; set; }

        public ProviderInsulatingsDto ProviderInsulatings { get; set; }
        public ProviderConcretesDto ProviderConcretes{ get; set; }

        public BudgetCiRowsDto()
        {
            ProviderInsulatings = new ProviderInsulatingsDto();
            ProviderConcretes = new ProviderConcretesDto();
        }

    }
}

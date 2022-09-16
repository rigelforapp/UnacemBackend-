using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;

namespace UNACEM.Service.Queries.DTO
{
    public class BudgetCiDto
    {
        public int Id { get; set; }
        public string Line { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }

        public List<BudgetCiRowsDto> Rows { get; set; }
        public List<BudgetCiCurrencyDto> Currencies { get; set; }

       public BudgetCiDto() {
            Rows = new List<BudgetCiRowsDto>();
            Currencies= new List<BudgetCiCurrencyDto>();

        }
    }
}
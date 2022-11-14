using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;

namespace UNACEM.Service.Queries.DTO
{
    public class BudgetsDto
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public double TotalAmount { get; set; }
        public string Description { get; set; }
        public int OvenLarge { get; set; }
        public int OvenDiameter { get; set; }
        public int ProviderId { get; set; }
        public List<BudgetsStrechesDTO> budgetStretches { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}

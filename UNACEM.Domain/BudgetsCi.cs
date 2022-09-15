using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BudgetsCi : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public string Line { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public double? Total { get; set; }
    }
}

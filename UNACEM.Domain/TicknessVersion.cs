using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class TicknessVersions : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int TicknessId { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class TicknessVersionRegisters : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int TicknessVersionId { get; set; }
        public int Position { get; set; }
        public int Value { get; set; }

    }
}

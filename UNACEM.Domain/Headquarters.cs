using System.Collections.Generic;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Headquarters : AuditFields, IAuditFields
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

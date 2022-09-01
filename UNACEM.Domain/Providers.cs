using System;
using System.Collections.Generic;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Providers : AuditFields, IAuditFields
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public string Deleted_By { get; set; }

    }
}

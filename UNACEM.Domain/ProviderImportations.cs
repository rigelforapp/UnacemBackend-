using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class ProviderImportations : AuditFields, IAuditFields
    {
        public int ProviderImportationId { get; set; }
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public virtual Providers Providers { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public string Deleted_By { get; set; }

    }
}

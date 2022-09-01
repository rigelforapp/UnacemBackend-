using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class ProviderImportations : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int Provider_Id { get; set; }
        [ForeignKey("Provider_Id")]
        public virtual Providers Providers { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public string Deleted_By { get; set; }

    }
}

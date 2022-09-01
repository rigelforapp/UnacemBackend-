using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public abstract class AuditFields : IAuditFields
    {

        public DateTime? Created_At { get; set; }

        public DateTime? Updated_At { get; set; }

        public DateTime? Deleted_At { get; set; }
    }
}

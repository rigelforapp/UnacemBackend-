using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public abstract class AuditFields : IAuditFields
    {

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}

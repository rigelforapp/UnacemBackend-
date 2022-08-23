using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public abstract class AuditFields : IAuditFields
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [MaxLength(20)]
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

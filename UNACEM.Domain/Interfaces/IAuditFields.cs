using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UNACEM.Domain.Interfaces
{
    public interface IAuditFields
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UNACEM.Domain.Interfaces
{
    public interface IAuditFields
    {
        public DateTime? Created_At { get; set; }

        public DateTime? Updated_At { get; set; }

        public DateTime? Deleted_At { get; set; }
    }
}

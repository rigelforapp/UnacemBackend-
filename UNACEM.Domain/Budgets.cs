﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Budgets : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int Version_Id { get; set; }
        [ForeignKey("Version_Id")]
        public virtual Versions Versions { get; set; }
        public double Total_Amount { get; set; }
     
    }
}

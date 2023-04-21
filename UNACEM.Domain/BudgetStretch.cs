using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BudgetStretch : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public double BrickACost { get; set; }
        public double BrickBCost { get; set; }

        public int? BrickFormatId { get; set; }
        [ForeignKey("BrickFormatId")]
        public virtual BrickFormats BrickFormats { get; set; }

        public int BrickLNormal { get; set; }
        public double positionIni { get; set; }
        public double positionEnd { get; set; }
        public int? ProviderBrickId { get; set; }
        public double TotalAmount { get; set; }
        public double WedgeAQuantity { get; set; }
        public double WedgeBQuantity { get; set; }
        public double WedgeACost { get; set; }
        public double WedgeBCost { get; set; }

        public int BudgetId { get; set; }
        [ForeignKey("BudgetId")]
        public virtual Budgets Budgets { get; set; }


        
        

        
        
        
    }
}

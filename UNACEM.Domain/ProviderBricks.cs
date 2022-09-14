using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class ProviderBricks : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public int ProviderImportationId { get; set; }
        [ForeignKey("ProviderImportationId")]
        public virtual ProviderImportations ProviderImportations { get; set; }
        public string Name { get; set; }
        public string RecommendedZone { get; set; }
        public string Composition { get; set; }
        public string Density { get; set; }
        public string Porosity { get; set; }
        public string Ccs { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal ThermalConductivity300 { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal ThermalConductivity700 { get; set; }
        [Column(TypeName = "decimal(5, 2)")] 
        public decimal ThermalConductivity100 { get; set; }

    }
}

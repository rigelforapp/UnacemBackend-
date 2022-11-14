using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class ProviderConcretes : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        
        public int ProviderImportationId { get; set; }
        [ForeignKey("ProviderImportationId")]
        public virtual ProviderImportations ProviderImportations { get; set; }

        public string Name { get; set; }
        public string RecommendedZone { get; set; }
        public string Composition { get; set; }
        public string MaterialNeeded { get; set; }
        public string WaterMix { get; set; }
        public string Temperature { get; set; }
        public string ThermalConductivity300 { get; set; }
        public string ThermalConductivity700 { get; set; }
        public string ThermalConductivity100 { get; set; }
    }
}

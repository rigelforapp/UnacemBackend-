using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class ProviderInsulatings: AuditFields, IAuditFields
    {
        public int Id { get; set; }

        public int ProviderImportationsId { get; set; }
        [ForeignKey("ProviderImportationsId")]
        public virtual ProviderImportations ProviderImportations { get; set; }

        public string Name { get; set; }
        public string RecommendedZone { get; set; }
        public string Composition { get; set; }
        public double MaterialNeeded { get; set; }
        public string WaterMix { get; set; }
        public double Temperature { get; set; }
        public double ThermalConductivity300 { get; set; }
        public double ThermalConductivity700 { get; set; }
        public double ThermalConductivity100 { get; set; }
    }
}

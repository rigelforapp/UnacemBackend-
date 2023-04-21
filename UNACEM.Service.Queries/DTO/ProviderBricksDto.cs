using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class ProviderBricksDto
    {
        public int Id { get; set; }
        public int ProviderImportationId { get; set; }
        public string Name { get; set; }
        public string RecommendedZone { get; set; }
        public string Composition { get; set; }
        public string Density { get; set; }
        public string Porosity { get; set; }
        public string Ccs { get; set; }
        public string ThermalConductivity300 { get; set; }
        public string ThermalConductivity700 { get; set; }
        public string ThermalConductivity100 { get; set; }
    }
}

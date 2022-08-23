using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class ProviderBricksDto
    {
        public int ProviderBrickId { get; set; }
        public int ProviderImportationId { get; set; }
        public string Name { get; set; }
        public string Recommended_Zone { get; set; }
        public string Composition { get; set; }
        public string Density { get; set; }
        public string Porosity { get; set; }
        public string Ccs { get; set; }
        public decimal Thermal_Conductivity_300 { get; set; }
        public decimal Thermal_Conductivity_700 { get; set; }
        public decimal Thermal_Conductivity_100 { get; set; }
    }
}

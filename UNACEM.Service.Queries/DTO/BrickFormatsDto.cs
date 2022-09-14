using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class BrickFormatsDto
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string BrickA { get; set; }
        public string BrickB { get; set; }
        public int QuantityA { get; set; }
        public int QuantityB { get; set; }
        public int Diameter { get; set; }
    }
}

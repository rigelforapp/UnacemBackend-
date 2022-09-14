using System;
using System.Collections.Generic;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BrickFormats : AuditFields, IAuditFields
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

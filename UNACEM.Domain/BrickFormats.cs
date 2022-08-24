using System;
using System.Collections.Generic;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class BrickFormats : AuditFields, IAuditFields
    {
        public int BrickFormatId { get; set; }
        public string Group { get; set; }
        public string Brick_a { get; set; }
        public string Brick_b { get; set; }
        public int Quantity_a { get; set; }
        public int Quantity_b { get; set; }
        public int Diameter { get; set; }
        
    }
}

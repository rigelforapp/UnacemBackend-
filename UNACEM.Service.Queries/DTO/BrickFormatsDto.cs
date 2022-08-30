using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class BrickFormatsDto
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string Brick_a { get; set; }
        public string Brick_b { get; set; }
        public int Quantity_a { get; set; }
        public int Quantity_b { get; set; }
        public int Diameter { get; set; }
    }
}

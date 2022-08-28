using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class OvensDto
    {
        public int OvenId { get; set; }
        public int HeadquarterId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Large { get; set; }
        public int Diameter { get; set; }
    }
}

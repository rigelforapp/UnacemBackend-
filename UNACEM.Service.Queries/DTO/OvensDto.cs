using System;
using System.Collections.Generic;
using System.Text;
using UNACEM.Domain;

namespace UNACEM.Service.Queries.DTO
{
    public class OvensDto
    {
        public int Id { get; set; }
        public string Headquarter { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal Large { get; set; }
        public int Diameter { get; set; }
        public int QuantityVersions { get; set; }
        public int QuantityBudgets { get; set; }
        public string LastDateEnd{ get; set; }

        public List<Tyres> tyres { get; set; }
    }
}

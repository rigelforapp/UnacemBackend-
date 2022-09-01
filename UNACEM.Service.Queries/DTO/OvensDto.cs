using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class OvensDto
    {
        public int Id { get; set; }
        public int HeadquarterId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Large { get; set; }
        public int Diameter { get; set; }
        public int QuantityVersions { get; set; }
        public int QuantityBudgets { get; set; }
        public string Last_date_end{ get; set; }
    }
}

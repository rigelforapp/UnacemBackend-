using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;

namespace UNACEM.Service.Queries.DTO
{
    public class TicknessVersionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TicknessVersionRegisters> Registers { get; set; }
    }
}

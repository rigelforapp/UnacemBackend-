using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class TicknessVersionRequest
    {
        public int Id { get; set; }
        public int TicknessId { get; set; }
        public string Name { get; set; }
        public List<TicknessVersionRegisterRequest> Registers { get; set; }
    }
}

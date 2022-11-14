using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class TicknessVersionRegisterRequest
    {
        public int Id {get; set;}
        public int TicknessVersionId { get; set; }
        public int Position { get; set; }
        public int Value { get; set; }
    }
}

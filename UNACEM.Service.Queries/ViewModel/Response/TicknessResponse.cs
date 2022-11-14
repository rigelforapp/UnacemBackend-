using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Service.Queries.DTO;

namespace UNACEM.Service.Queries.ViewModel.Response
{
    public class TicknessResponse: ResponseBase
    {
        public List<TicknessDto> Data { get; set; }
    }
}

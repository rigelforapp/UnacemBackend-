using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;
using UNACEM.Service.Queries.DTO;

namespace UNACEM.Service.Queries.ViewModel.Response
{
    public class ResourcesResponse: ResponseBase
    {
        public List<object> Data { get; set; }
    }
}

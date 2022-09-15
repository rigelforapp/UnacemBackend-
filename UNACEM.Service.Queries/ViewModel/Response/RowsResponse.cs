using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.ViewModel.Response
{
    public class RowsResponse : ResponseBase
    {
        public List<object> Data { get; set; }
    }
}

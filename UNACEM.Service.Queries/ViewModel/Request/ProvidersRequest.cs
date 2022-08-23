using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class ProvidersRequest
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Response
{

    public class ResponseBase
    {
        public ResponseBase()
        {
            this.Success = true;
        }

        public object Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Details { get { return ""; } set { } }
        public List<string> Messages { get; set; }
    }
}

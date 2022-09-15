using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Domain;
using UNACEM.Service.Queries.DTO;

namespace UNACEM.Service.Queries.ViewModel.Response
{
    public class CurrencyResponse : ResponseBase
    {
        public List<object> Data { get; set; }
    }
}

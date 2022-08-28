using System;
using System.Collections.Generic;
using System.Text;
using UNACEM.Service.Queries.DTO;

namespace UNACEM.Service.Queries.ViewModel.Response
{
    public class StretchsResponse : ResponseBase
    {
        public List<StretchsDto> ListaStrech { get; set; }
    }
}

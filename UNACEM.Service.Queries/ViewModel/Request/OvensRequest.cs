using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class OvensRequest
    {
        public int Id { get; set; }
        public int HeadquarterId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal Large { get; set; }
        public int Diameter { get; set; }
        public List<TyresRequest> Tyres { get; set; }

        public OvensRequest()
        {
            Tyres = new List<TyresRequest>();
        }

    }
}

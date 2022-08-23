using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class OvensRequest
    {
        public int OvenId { get; set; }
        public int HeadquarterId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Large { get; set; }
        public int Diameter { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public List<TyresRequest> Tyres { get; set; }
    }
}

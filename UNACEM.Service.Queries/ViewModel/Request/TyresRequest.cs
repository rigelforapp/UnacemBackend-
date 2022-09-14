using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class TyresRequest
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int TextureId { get; set; }
        public double Position { get; set; }
    }
}

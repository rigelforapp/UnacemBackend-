using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class StretchsRequest
    {
        public int Id { get; set; }
        public int Version_Id { get; set; }
        public double Position_Ini { get; set; }
        public double Position_End { get; set; }
        public int Color_Id { get; set; }
        public int Texture_Id { get; set; }
        public int ProviderBrick_Id { get; set; }
        public int BrickFormat_Id { get; set; }
        public string Created_By { get; set; }
    }
}

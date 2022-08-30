using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class StretchsRequest
    {
        public int StretchId { get; set; }
        public int VersionId { get; set; }
        public double Position_Ini { get; set; }
        public double Position_End { get; set; }
        public int Color_Id { get; set; }
        public int Texture_Id { get; set; }
        public int ProviderBrickId { get; set; }
        public int BrickFormatId { get; set; }
        public string CreatedBy { get; set; }
    }
}

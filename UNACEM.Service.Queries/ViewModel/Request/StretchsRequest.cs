using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class StretchsRequest
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public double PositionIni { get; set; }
        public double PositionEnd { get; set; }
        public int ColorId { get; set; }
        public int TextureId { get; set; }
        public int ProviderBrickId { get; set; }
        public int BrickFormatId { get; set; }
        public string CreatedBy { get; set; }
    }
}

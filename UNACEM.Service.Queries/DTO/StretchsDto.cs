using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class StretchsDto
    {
        public int Id { get; set; }
        public double PositionIni { get; set; }
        public double PositionEnd { get; set; }
        public int ColorId { get; set; }
        public int TextureId { get; set; }
        public int ProviderBrickId { get; set; }
        public int BrickFormatId { get; set; }
    }
}

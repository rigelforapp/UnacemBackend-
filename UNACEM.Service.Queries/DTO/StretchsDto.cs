using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class StretchsDto
    {
        public int Id { get; set; }
        public double Position_Ini { get; set; }
        public double Position_End { get; set; }
        public int Color_Id { get; set; }
        public int Texture_Id { get; set; }
        public int ProviderBrickId { get; set; }
        public int BrickFormatId { get; set; }
    }
}

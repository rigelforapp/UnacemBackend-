using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class VersionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date_Ini { get; set; }
        public DateTime Date_End { get; set; }
        public string DateIni { get; set; }
        public string DateEnd { get; set; }
    }
}

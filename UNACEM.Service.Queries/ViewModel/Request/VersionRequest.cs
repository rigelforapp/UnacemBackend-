using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class VersionRequest
    {
        public int VersionId { get; set; }
        public int OvenId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Date_Ini { get; set; }
        public DateTime Date_End { get; set; }
        public string DateIni { get; set; }
        public string DateEnd { get; set; }        
    }
}

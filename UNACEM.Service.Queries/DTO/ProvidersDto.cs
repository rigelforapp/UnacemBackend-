using System;
using System.Collections.Generic;
using System.Text;

namespace UNACEM.Service.Queries.DTO
{
    public class ProvidersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastImportationDate { get; set; }
    }
}

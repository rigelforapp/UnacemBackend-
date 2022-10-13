using System;
using System.Collections.Generic;
using System.Text;
using UNACEM.Domain;

namespace UNACEM.Service.Queries.DTO
{
    public class VersionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateIni { get; set; }
        public DateTime DateEnd { get; set; }

        public List<Stretchs> Stretchs { get; set; }

    }
}

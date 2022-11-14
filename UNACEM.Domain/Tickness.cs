using System;
using System.Collections.Generic;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Tickness : AuditFields, IAuditFields
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int UserId { get; set; }
    }
}

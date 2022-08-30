﻿using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Users : AuditFields, IAuditFields
    {
        public int UserId{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}

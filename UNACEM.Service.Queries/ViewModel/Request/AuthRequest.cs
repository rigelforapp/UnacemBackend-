﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.ViewModel.Request
{
    public class AuthRequest
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public string? refreshToken { get; set; }
    }
}

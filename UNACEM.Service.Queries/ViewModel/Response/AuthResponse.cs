using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNACEM.Service.Queries.ViewModel.Response
{
    public class AuthResponse : ResponseBase
    {       
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int ExpireIn { get; set; }
        public UserResponse User { get; set; }
    }
}

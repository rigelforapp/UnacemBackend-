namespace UNACEM.API.Helpers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using UNACEM.Domain;
    using UNACEM.Persistence.Database;

    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ApplicationDbContext applicationContext)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, token, applicationContext);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, string token, ApplicationDbContext applicationContext)
        {
            try
            {

                var user = applicationContext.Users.Where(u => u.Token == token).FirstOrDefault();

                if (user != null)
                {
                    context.Items["User"] = user;
                }
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}

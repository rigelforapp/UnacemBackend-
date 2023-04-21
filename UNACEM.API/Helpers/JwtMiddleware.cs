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
            var jwt = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (jwt != null) {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);
                var expiration = token.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
                var expirationDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiration)).DateTime;

                // Crear una instancia de TimeZoneInfo para GMT
                TimeZoneInfo gmt = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                DateTime now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, gmt);

                if (expirationDate < now)
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Acceso denegado");
                } else
                {
                    attachUserToContext(context, jwt, applicationContext);
                }
            }   

            await _next(context);
            /*
             ar authHeader = context.Request.Headers["Authorization"];
            var jwt = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var ruta = context.Request.Path;

            if (ruta == "/authentication") {
                await _next(context);
            } else
            {
                if (jwt != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(jwt);

                    var expiration = token.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;

                    if (token != null)
                        attachUserToContext(context, jwt, applicationContext);

                    await _next(context);
                }
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Acceso denegado");
            }  
             
             */
        }

        private void attachUserToContext(HttpContext context, string token, ApplicationDbContext applicationContext)
        {
            try
            {

                //var user = applicationContext.Users.Where(u => u.Token == token).FirstOrDefault();
                var user = applicationContext.Users.Where(u => u.Email == "ext_prueba_mulesoft@unacem.pe").FirstOrDefault();

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

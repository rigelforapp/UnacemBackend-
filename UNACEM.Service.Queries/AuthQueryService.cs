using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNACEM.Persistence.Database;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;
using RestSharp;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators;
using System.IdentityModel.Tokens.Jwt;

namespace UNACEM.Service.Queries
{
    public interface IAuthQueryService
    {
        Task<AuthResponse> auth(AuthRequest authRequest);
        Task<AuthResponse> refresh(string refreshToken); 
    }

    public class AuthQueryService : IAuthQueryService
    {
        private readonly ApplicationDbContext _context;
        public AuthQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AuthResponse> auth(AuthRequest authRequest)
        {
            var response = new AuthResponse();
            try
            {
                var options = new RestClientOptions("https://seguridad-unacem.us-e1.cloudhub.io/api/rest/security/security-oauth/oauth/8d281a5e-0271-4fb0-b011-d0e968cbd61d/token")
                {
                    MaxTimeout = -1  // 1 second
                };

                var client = new RestClient(options);
                client.Authenticator = new HttpBasicAuthenticator("frontendapp", "12345");

                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("username", authRequest.username);
                request.AddParameter("password", authRequest.password);
                request.AddParameter("client_id", "413132f5-07c5-4652-9e3f-f4f2c6cec04a");
                request.AddParameter("client_secret", "_~F8Q~saLj4W8084YpNcBH3-N~MFs2dU91JRNc1F");
                request.AddParameter("grant_type", "password");

                var restResponse = client.Execute(request);

                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = restResponse.Content;
                    JObject json = JObject.Parse(content);

                    var access_token = json.Value<string>("access_token");
                    var refresh_token = json.Value<string>("refresh_token");

                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(access_token);
                    var email = token.Claims.FirstOrDefault(c => c.Type == "upn")?.Value;
                    var expiration = token.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
                    var Expirein = json.Value<int>("expires_in") * 1000 * 1000;


                    //Get user;
                    var uLoged = _context.Users.Where(u => u.Email == email).FirstOrDefault();

                    if (uLoged != null)
                    {
                        UserResponse uResponse = new UserResponse();
                        uResponse.Name = uLoged.Name;
                        uResponse.Email = uLoged.Email;

                        response.RefreshToken = refresh_token;
                        response.Token = access_token;
                        response.ExpireIn = Int32.Parse(expiration);
                        response.User = uResponse;
                        
                    }
                    else
                    {
                        response.Success = false;
                    }
                }
                else
                {
                    response.Success = false;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return response;
        }

        public async Task<AuthResponse> refresh(string refreshToken)
        {
            var response = new AuthResponse();
            try
            {
                /*var options = new RestClientOptions("https://seguridad-unacem.us-e1.cloudhub.io/api/rest/security/security-oauth/oauth/8d281a5e-0271-4fb0-b011-d0e968cbd61d/refresh")
                {
                    MaxTimeout = -1  // 1 second
                };*/

                var options = new RestClientOptions("https://seguridad-unacem.us-e1.cloudhub.io/api/rest/security/security-oauth/oauth/refresh")
                {
                    MaxTimeout = -1  // 1 second
                };

                var client = new RestClient(options);
                client.Authenticator = new HttpBasicAuthenticator("frontendapp", "12345");

                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("refresh_token", refreshToken);
                request.AddParameter("client_id", "413132f5-07c5-4652-9e3f-f4f2c6cec04a");
                request.AddParameter("client_secret", "_~F8Q~saLj4W8084YpNcBH3-N~MFs2dU91JRNc1F");
                request.AddParameter("grant_type", "password");

                var restResponse = client.Execute(request);

                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var content = restResponse.Content;
                    JObject json = JObject.Parse(content);

                    var access_token = json.Value<string>("access_token");
                    var refresh_token = json.Value<string>("refresh_token");

                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(access_token);
                    var email = token.Claims.FirstOrDefault(c => c.Type == "upn")?.Value;
                    var expiration = token.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
                    var Expirein = json.Value<int>("expires_in") * 1000 * 1000;


                    //Get user;
                    var uLoged = _context.Users.Where(u => u.Email == email).FirstOrDefault();

                    if (uLoged != null)
                    {
                        UserResponse uResponse = new UserResponse();
                        uResponse.Name = uLoged.Name;
                        uResponse.Email = uLoged.Email;

                        response.RefreshToken = refresh_token;
                        response.Token = access_token;
                        response.ExpireIn = Int32.Parse(expiration);
                        response.User = uResponse;

                    }
                    else
                    {
                        response.Success = false;
                    }
                }
                else
                {
                    response.Success = false;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return response;
        }
    }
}

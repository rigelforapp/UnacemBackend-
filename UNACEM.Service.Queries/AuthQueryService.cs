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
                var options = new RestClientOptions("https://seguridad-unacem-dev.us-e1.cloudhub.io/api/rest/security/security-oauth/oauth/token")
                {
                    MaxTimeout = -1  // 1 second
                };

                var client = new RestClient(options);
                client.Authenticator = new HttpBasicAuthenticator("frontendapp", "12345");

                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("username", authRequest.username);
                request.AddParameter("password", authRequest.password);
                request.AddParameter("client_id", "e8c8cc0d-f376-4948-9f35-55d1f7841537");
                request.AddParameter("client_secret", "BP18Q~AKwER~5HNOTU7O8LZ~PksG4rx5~N91EbzD");
                request.AddParameter("grant_type", "password");

                var restResponse = client.Execute(request);

                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    //Get user;
                    var uLoged = _context.Users.Where(u => u.Email == authRequest.username).FirstOrDefault();

                    if (uLoged != null)
                    {
                        var content = restResponse.Content;
                        JObject json = JObject.Parse(content);

                        uLoged.ExpireIn = json.Value<int>("expires_in");
                        uLoged.Token = json.Value<string>("access_token");
                        uLoged.RefreshToken = json.Value<string>("refresh_token");

                        await _context.SaveChangesAsync();

                        UserResponse uResponse = new UserResponse();
                        uResponse.Name = uLoged.Name;
                        uResponse.Email = uLoged.Email;

                        response.RefreshToken = uLoged.RefreshToken;
                        response.Token = uLoged.Token ?? "";
                        response.ExpireIn = uLoged.ExpireIn ?? 0;
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
                var options = new RestClientOptions("https://seguridad-unacem-dev.us-e1.cloudhub.io/api/rest/security/security-oauth/oauth/refresh")
                {
                    MaxTimeout = -1  // 1 second
                };

                var client = new RestClient(options);
                client.Authenticator = new HttpBasicAuthenticator("frontendapp", "12345");

                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("client_id", "e8c8cc0d-f376-4948-9f35-55d1f7841537");
                request.AddParameter("client_secret", "BP18Q~AKwER~5HNOTU7O8LZ~PksG4rx5~N91EbzD");
                request.AddParameter("refresh_token", refreshToken);

                var restResponse = client.Execute(request);

                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    //Get user;
                    var uLoged = _context.Users.Where(u => u.RefreshToken == refreshToken).FirstOrDefault();

                    if (uLoged != null)
                    {
                        var content = restResponse.Content;
                        JObject json = JObject.Parse(content);

                        uLoged.ExpireIn = json.Value<int>("expires_in");
                        uLoged.Token = json.Value<string>("access_token");
                        uLoged.RefreshToken = json.Value<string>("refresh_token");

                        await _context.SaveChangesAsync();

                        UserResponse uResponse = new UserResponse();
                        uResponse.Name = uLoged.Name;
                        uResponse.Email = uLoged.Email;

                        response.Token = uLoged.Token ?? "";
                        response.RefreshToken = uLoged.RefreshToken;
                        response.ExpireIn = uLoged.ExpireIn ?? 0;
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

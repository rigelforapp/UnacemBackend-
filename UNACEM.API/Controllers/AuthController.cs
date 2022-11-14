using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthQueryService _authQueryService;

        public AuthController(IAuthQueryService authQueryService)
        {
            _authQueryService = authQueryService;
        }

        

        [HttpPost]
        public async Task<object> auth(AuthRequest authRequest)
        {            
            return await _authQueryService.auth(authRequest);
        }

        [HttpPost("refresh")]
        public async Task<object> refresh(AuthRequest authRequest)
        {
            return await _authQueryService.refresh(authRequest.refreshToken);
        }
    }
}

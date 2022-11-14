using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNACEM.API.Authorization;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("currencies")]
    [Auth]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyQueryService _currencyQueryService;

        public CurrencyController(ICurrencyQueryService currencyQueryService)
        {
            _currencyQueryService = currencyQueryService;
        }

        [HttpPost]
        public async Task<CurrencyResponse> Create(CurrencyRequest request)
        {
            return await _currencyQueryService.Create(request);
        }

        [HttpPut]
        public async Task<CurrencyResponse> Update(CurrencyRequest request)
        {
            return await _currencyQueryService.Update(request);
        }

        [HttpDelete]
        public async Task<CurrencyResponse> Delete(CurrencyRequest request)
        {
            return await _currencyQueryService.Delete(request);
        }

        [HttpGet]
        public async Task<CurrencyResponse> GetAll(string type = "budget", int entityId = 0 )
        {
            return await _currencyQueryService.GetAll(type, entityId);
        }
    }
}
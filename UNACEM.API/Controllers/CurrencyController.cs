using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("budgetCI/Currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyQueryService _currencyQueryService;

        public CurrencyController(ICurrencyQueryService currencyQueryService)
        {
            _currencyQueryService = currencyQueryService;
        }

        [HttpPost]
        public async Task<CurrencyResponse> Create(BudgetCiCurrencyRequest budgetCiCurrencyRequest)
        {
            return await _currencyQueryService.Create(budgetCiCurrencyRequest);
        }

        [HttpPut]
        public async Task<CurrencyResponse> Update(BudgetCiCurrencyRequest budgetCiCurrencyRequest)
        {
            return await _currencyQueryService.Update(budgetCiCurrencyRequest);
        }

        [HttpDelete]
        public async Task<CurrencyResponse> Delete(BudgetCiCurrencyRequest budgetCiCurrencyRequest)
        {
            return await _currencyQueryService.Delete(budgetCiCurrencyRequest);
        }

        [HttpGet]
        public async Task<CurrencyResponse> GetAll(BudgetCiCurrencyRequest budgetCiCurrencyRequest)
        {
            return await _currencyQueryService.GetAll(budgetCiCurrencyRequest);
        }
    }
}
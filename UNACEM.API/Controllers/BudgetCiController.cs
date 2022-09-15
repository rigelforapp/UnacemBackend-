using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("budgetCI")]
    public class BudgetCiController : ControllerBase
    {
        private readonly IBudgetCiQueryService _budgetCiQueryService;

        public BudgetCiController(IBudgetCiQueryService budgetCiQueryService)
        {
            _budgetCiQueryService = budgetCiQueryService;
        }

        [HttpPost]
        public async Task<BudgetCiResponse> Create(BudgetCiRequest budgetCiRowsRequest)
        {
            return await _budgetCiQueryService.Create(budgetCiRowsRequest);
        }

        [HttpPut]
        public async Task<BudgetCiResponse> Update(BudgetCiRequest budgetCiRequest)
        {
            return await _budgetCiQueryService.Update(budgetCiRequest);
        }

        [HttpDelete]
        public async Task<BudgetCiResponse> Delete(BudgetCiRequest budgetCiRequest)
        {
            return  await _budgetCiQueryService.Delete(budgetCiRequest);
        }
    }
}
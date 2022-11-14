using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNACEM.API.Authorization;
using UNACEM.Domain;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    [ApiController]
    [Route("budgets-ci")]
    [Auth]
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
            return await _budgetCiQueryService.Create(budgetCiRowsRequest, (Users)HttpContext.Items["User"]);
        }

        [HttpPut]
        public async Task<BudgetCiResponse> Update(BudgetCiRequest budgetCiRequest)
        {
            return await _budgetCiQueryService.Update(budgetCiRequest, (Users)HttpContext.Items["User"]);
        }

        [HttpGet]
        public async Task<object> GetAll(int start, int limit)
        {
            return await _budgetCiQueryService.GetAll(start, limit, (Users)HttpContext.Items["User"]);
        }
    }
}
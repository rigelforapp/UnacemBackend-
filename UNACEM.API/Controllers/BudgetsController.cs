using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("Budgets")]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetsQueryService _budgetsQueryService;

        public BudgetsController(IBudgetsQueryService budgetsQueryService)
        {
            _budgetsQueryService = budgetsQueryService;
        }

        [HttpGet("GetAll")]
        public async Task<BudgetsResponse> GetAll(int VersionId, int Start, int Limit)
        {
            return await _budgetsQueryService.GetAll(VersionId, Start, Limit);
        }

        [HttpPost("Create")]
        public async Task<BudgetsResponse> Create(BudgetsRequest budgetsRequest)
        {
            return await _budgetsQueryService.Create(budgetsRequest);
        }
    }
}

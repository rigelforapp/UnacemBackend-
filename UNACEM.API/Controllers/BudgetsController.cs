using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNACEM.Common.Configuration;
using UNACEM.Service.Queries;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;

namespace UNACEM.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("Ovens/Budgets")]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetsQueryService _budgetsQueryService;

        public BudgetsController(IBudgetsQueryService budgetsQueryService)
        {
            _budgetsQueryService = budgetsQueryService;
        }

        [HttpGet]
        public async Task<BudgetsResponse> GetAll(int VersionId, int Start = Manager.VariableGlobal.Numero.Uno, int Limit = Manager.VariableGlobal.Numero.Diez)
        {
            return await _budgetsQueryService.GetAll(VersionId, Start, Limit);
        }

        [HttpPost]
        public async Task<BudgetsResponse> Create(BudgetsRequest budgetsRequest)
        {
            return await _budgetsQueryService.Create(budgetsRequest);
        }
    }
}

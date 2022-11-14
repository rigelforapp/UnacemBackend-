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
    [Route("budget-ci/row")]
    [Auth]
    public class RowsController : ControllerBase
    {
        private readonly IRowsQueryService _rowsQueryService;

        public RowsController(IRowsQueryService rowsQueryService)
        {
            _rowsQueryService = rowsQueryService;
        }
        [HttpPost]
        public async Task<RowsResponse> Create(BudgetCiRowsRequest budgetCiRowsRequest)
        {
            return await _rowsQueryService.Create(budgetCiRowsRequest);
        }

        [HttpDelete]
        public async Task<RowsResponse> Delete(BudgetCiRowsRequest budgetCiRowsRequest)
        {
            return await _rowsQueryService.Delete(budgetCiRowsRequest);
        }

        [HttpPut]
        public async Task<RowsResponse> Update(BudgetCiRowsRequest budgetCiRowsRequest)
        {
            return await _rowsQueryService.Update(budgetCiRowsRequest);
        }
    }
}

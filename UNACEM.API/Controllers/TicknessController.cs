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
    [Route("tickness")]
    [Auth]
    public class TicknessController : ControllerBase
    {
        private readonly ITicknessQueryService _ticknessQueryService;

        public TicknessController(ITicknessQueryService ticknessQueryService)
        {
            _ticknessQueryService = ticknessQueryService;
        }

        [HttpPost]
        public async Task<TicknessResponse> Create(TicknessRequest budgetCiRowsRequest)
        {
            return await _ticknessQueryService.Create(budgetCiRowsRequest, (Users)HttpContext.Items["User"]);
        }

        [HttpPut]
        public async Task<TicknessResponse> Update(TicknessRequest budgetCiRequest)
        {
            return await _ticknessQueryService.Update(budgetCiRequest, (Users)HttpContext.Items["User"]);
        }

        [HttpDelete]
        public async Task<TicknessResponse> Delete(TicknessRequest budgetCiRequest)
        {
            return await _ticknessQueryService.Delete(budgetCiRequest, (Users)HttpContext.Items["User"]);
        }

        [HttpGet]
        public async Task<object> GetAll(int start, int limit)
        {
            return await _ticknessQueryService.GetAll(start, limit, (Users)HttpContext.Items["User"]);
        }
    }
}

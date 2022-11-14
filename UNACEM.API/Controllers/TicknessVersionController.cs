using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UNACEM.Service.Queries.ViewModel.Request;
using UNACEM.Service.Queries.ViewModel.Response;
using UNACEM.Service.Queries;
using UNACEM.API.Authorization;

namespace UNACEM.API.Controllers
{

    [ApiController]
    [Route("tickness/version")]
    [Auth]
    public class TicknessVersionController : ControllerBase
    {
        private readonly ITicknessVersionQueryService _ticknessVersionQueryService;

        public TicknessVersionController(ITicknessVersionQueryService _ticknessVersionQueryService)
        {
            this._ticknessVersionQueryService = _ticknessVersionQueryService;
        }

        [HttpPost]
        public async Task<TicknessVersionResponse> Create(TicknessVersionRequest ticknessVersionRequest)
        {
            return await _ticknessVersionQueryService.Create(ticknessVersionRequest);
        }

        [HttpPut]
        public async Task<TicknessVersionResponse> Update(TicknessVersionRequest ticknessVersionRequest)
        {
            return await _ticknessVersionQueryService.Update(ticknessVersionRequest);
        }

        [HttpDelete]
        public async Task<TicknessVersionResponse> Delete(TicknessVersionRequest ticknessVersionRequest)
        {
            return await _ticknessVersionQueryService.Delete(ticknessVersionRequest);
        }

        [HttpGet]
        public async Task<object> GetAll(int start, int limit, int ticknessId)
        {
            return await _ticknessVersionQueryService.GetAll(start, limit, ticknessId);
        }
    }
}

using System.Threading.Tasks;
using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicRedisLeaderboardDemoDotNetCore.Controllers
{
    public class RankController : ApiController
    {
        public readonly IRankService _rankService;
        public RankController(IRankService rankService)
        {
            _rankService = rankService;
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update([FromQuery(Name = "symbol")] string symbol, [FromQuery(Name = "amount")] double amount)
        {
            var res = await _rankService.Update(symbol, amount);
            return Ok(new { success = res });
        }
    }
}

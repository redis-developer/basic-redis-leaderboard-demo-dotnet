using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRedisLeaderboardDemoDotNetCore.Controllers
{
    public class RankController : ApiController
    {
        public readonly IRankService rankService;
        public RankController(IRankService rankService)
        {
            this.rankService = rankService;
        }

        [HttpGet("update")]
        public IActionResult Update([FromQuery(Name = "symbol")] string symbol, [FromQuery(Name = "amount")] double amount)
        {
            var res = rankService.Update(symbol, amount);
            return Ok(new { success = res });
        }
    }
}

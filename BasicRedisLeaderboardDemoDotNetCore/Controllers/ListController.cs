using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRedisLeaderboardDemoDotNetCore.Controllers
{
    public class ListController : ApiController
    {
        public readonly IRankService rankService;
        public ListController(IRankService rankService)
        {
            this.rankService = rankService;
        }

        [HttpGet("top10")]
        public IActionResult GetTop10()
        {
            return Ok(rankService.Range(0, 9, true));
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(rankService.Range(0, -1, true));
        }

        [HttpGet("bottom10")]
        public IActionResult GetBottom10()
        {
            return Ok(rankService.Range(0, 9, false));
        }

        [HttpGet("inRank")]
        public IActionResult GetInRank([FromQuery(Name = "start")]int start, [FromQuery(Name = "end")] int end)
        {
            return Ok(rankService.Range(start, end, true));
        }

        [HttpGet("getBySymbol")]
        public IActionResult GetBySymbol([FromQuery(Name = "symbols[]")] List<string> symbols)
        {
            return Ok(rankService.GetBySymbols(symbols));
        }
    }
}

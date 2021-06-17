using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicRedisLeaderboardDemoDotNetCore.Controllers
{
    public class ListController : ApiController
    {
        public readonly IRankService _rankService;
        public ListController(IRankService rankService)
        {
            _rankService = rankService;
        }

        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10()
        {
            return Ok(await _rankService.Range(0, 9, true));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rankService.Range(0, -1, true));
        }

        [HttpGet("bottom10")]
        public async Task<IActionResult> GetBottom10()
        {
            return Ok(await _rankService.Range(0, 9, false));
        }

        [HttpGet("inRank")]
        public async Task<IActionResult> GetInRank([FromQuery(Name = "start")]int start, [FromQuery(Name = "end")] int end)
        {
            return Ok(await _rankService.Range(start, end, true));
        }

        [HttpGet("getBySymbol")]
        public async Task<IActionResult> GetBySymbol([FromQuery(Name = "symbols[]")] List<string> symbols)
        {
            return Ok(await _rankService.GetBySymbols(symbols));
        }
    }
}

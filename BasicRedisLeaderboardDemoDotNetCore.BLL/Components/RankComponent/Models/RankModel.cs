using System;
using System.Collections.Generic;
using System.Text;

namespace BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Models
{
    public class RankModel
    {
        public string Company { get; set; }
        public string Symbol { get; set; }
        public long MarketCap { get; set; }
        public string Country { get; set; }
    }
}

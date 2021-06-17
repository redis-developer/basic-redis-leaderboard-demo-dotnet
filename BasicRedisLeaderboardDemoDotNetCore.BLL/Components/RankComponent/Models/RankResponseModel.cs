namespace BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Models
{
    public class RankResponseModel
    {
        public string Company { get; set; }
        public string Country { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public double MarketCap { get; set; }
    }
}

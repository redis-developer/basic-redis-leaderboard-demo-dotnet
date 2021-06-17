using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Models;
using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services.Interfaces;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services
{
    public class RankService : IRankService
    {
        private readonly IDatabase _redisClient;
        public RankService(IConnectionMultiplexer redis)
        {
            _redisClient = redis.GetDatabase();
        }

        public async Task<List<RankResponseModel>> Range(int start, int ent, bool isDesc)
        {
            var data = new List<RankResponseModel>();            
            var results = await _redisClient.SortedSetRangeByRankWithScoresAsync("REDIS_LEADERBOARD",start,ent, isDesc? Order.Descending:Order.Ascending);
            var startRank = isDesc ? start + 1 : (results.Count() / 2 - start);
            var increaseFactor = isDesc ? 1 : -1;
            var items = results.ToList();
            for (var i = 0; i < items.Count; i++)
            {
                var company = await GetCompanyBySymbol(items[i].Element);
                data.Add(
                    new RankResponseModel
                    {
                        Company = company.Item1,
                        Country = company.Item2,
                        Rank = startRank,
                        Symbol = items[i].Element,
                        MarketCap = items[i].Score,
                    });
                startRank += increaseFactor;
            }

            return data;
        }

        public async Task<(string, string)> GetCompanyBySymbol(string symbol)
        {
            var item = await _redisClient.HashGetAllAsync(symbol);
            return (item[0].ToString(), item[1].ToString());
        }

        public async Task<List<RankResponseModel>> GetBySymbols(List<string> symbols)
        {
            var results = new List<RankResponseModel>();
            for (var i = 0;i< symbols.Count; i++)
            {
                var score = await _redisClient.SortedSetScoreAsync("REDIS_LEADERBOARD", symbols[i]);
                var company = await GetCompanyBySymbol(symbols[i]);
                results.Add(
                     new RankResponseModel
                     {
                         Company = company.Item1,
                         Country = company.Item2,
                         Rank = i+1,
                         Symbol = symbols[i],
                         MarketCap = (double)score
                     });
            }
                
            return results;
        }

        public async Task<bool> Update(string symbol, double amount)
        {
            return await _redisClient.SortedSetAddAsync("REDIS_LEADERBOARD", symbol, amount);
        }
    }
}

using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Models;
using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services.Interfaces;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services
{
    public class RankService : IRankService
    {
        private readonly IRedisClient redisClient;
        public RankService(IRedisClient redisClient)
        {
            this.redisClient = redisClient;
        }

        public List<RankResponseModel> Range(int start, int ent, bool isDesc)
        {
            var data = new List<RankResponseModel>();
            var results = isDesc ? redisClient.GetRangeWithScoresFromSortedSetDesc("REDIS_LEADERBOARD", start, ent) : redisClient.GetRangeWithScoresFromSortedSet("REDIS_LEADERBOARD", start, ent);
            var startRank = isDesc ? start + 1 : (results.Count / 2 - start);
            var increaseFactor = isDesc ? 1 : -1;
            var items = results.Values.ToList();
            for (var i = 0; i < items.Count; i++)
            {
                var company = GetCompanyBySymbol(results.Keys.ToArray()[i]);
                data.Add(
                    new RankResponseModel
                    {
                        Company = company.Item1,
                        Country = company.Item2,
                        Rank = startRank,
                        Symbol = results.Keys.ToArray()[i],
                        MarketCap = results.Values.ToArray()[i],
                    });
                startRank += increaseFactor;
            }

            return data;
        }

        public (string, string) GetCompanyBySymbol(string symbol)
        {
            var item = redisClient.GetAllEntriesFromHash(symbol);
            return (item.Values.ToList()[0], item.Values.ToList()[1]);
        }

        public List<RankResponseModel> GetBySymbols(List<string> symbols)
        {
            var results = new List<RankResponseModel>();
            for (var i = 0;i< symbols.Count; i++)
            {
                var score = redisClient.GetItemScoreInSortedSet("REDIS_LEADERBOARD", symbols[i]);
                var company = GetCompanyBySymbol(symbols[i]);
                results.Add(
                     new RankResponseModel
                     {
                         Company = company.Item1,
                         Country = company.Item2,
                         Rank = i+1,
                         Symbol = symbols[i],
                         MarketCap = score
                     });
            }
                
            return results;
        }

        public bool Update(string symbol, double amount)
        {
            return redisClient.AddItemToSortedSet("REDIS_LEADERBOARD", symbol, amount);
        }
    }
}

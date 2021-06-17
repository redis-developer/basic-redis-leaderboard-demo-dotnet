using BasicRedisLeaderboardDemoDotNetCore.Base.Interfaces;
using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services.Interfaces
{
    public interface IRankService : IService
    {
        Task<List<RankResponseModel>> Range(int start, int ent, bool isDesc);
        Task<(string, string)> GetCompanyBySymbol(string symbol);
        Task<List<RankResponseModel>> GetBySymbols(List<string> symbols);

        Task<bool> Update(string symbol, double amount);
    }
}

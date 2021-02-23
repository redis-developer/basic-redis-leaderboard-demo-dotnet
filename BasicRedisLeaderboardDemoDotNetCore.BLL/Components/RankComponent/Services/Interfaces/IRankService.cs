using BasicRedisLeaderboardDemoDotNetCore.Base.Interfaces;
using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Services.Interfaces
{
    public interface IRankService : IService
    {
        List<RankResponseModel> Range(int start, int ent, bool isDesc);
        (string, string) GetCompanyBySymbol(string symbol);
        List<RankResponseModel> GetBySymbols(List<string> symbols);

        bool Update(string symbol, double amount);
    }
}

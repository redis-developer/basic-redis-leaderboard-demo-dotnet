using BasicRedisLeaderboardDemoDotNetCore.BLL.Components.RankComponent.Models;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicRedisLeaderboardDemoDotNetCore.BLL.DbContexts
{
    public class AppDbInitializer
    {
        public static async Task Seed(IServiceScope serviceScope)
        {
            
            var ranks = new List<RankModel>()
            {
                new RankModel {
                    Company= "Apple",
                    Symbol= "AAPL",
                    MarketCap= 2222000000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Saudi Aramco",
                    Symbol= "2222.SR",
                    MarketCap= 2046000000,
                    Country= "S. Arabia",
                  },
                new RankModel {
                    Company= "Microsoft",
                    Symbol= "MSFT",
                    MarketCap= 1660000000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Amazon",
                    Symbol= "AMZN",
                    MarketCap= 1597000000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Alphabet (Google)",
                    Symbol= "GOOG",
                    MarketCap= 1218000000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Tesla",
                    Symbol= "TSLA",
                    MarketCap= 834170000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Facebook",
                    Symbol= "FB",
                    MarketCap= 762110000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Tencent",
                    Symbol= "TCEHY",
                    MarketCap= 742230000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Alibaba",
                    Symbol= "BABA",
                    MarketCap= 642220000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Berkshire Hathaway",
                    Symbol= "BRK-A",
                    MarketCap= 549580000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Samsung",
                    Symbol= "005930.KS",
                    MarketCap= 526630000,
                    Country= "S. Korea",
                  },
                new RankModel {
                    Company= "TSMC",
                    Symbol= "TSM",
                    MarketCap= 511700000,
                    Country= "Taiwan",
                  },
                new RankModel {
                    Company= "Visa",
                    Symbol= "V",
                    MarketCap= 474940000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Johnson &amp; Johnson",
                    Symbol= "JNJ",
                    MarketCap= 421310000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Walmart",
                    Symbol= "WMT",
                    MarketCap= 414850000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "JPMorgan Chase",
                    Symbol= "JPM",
                    MarketCap= 414610000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Kweichow Moutai",
                    Symbol= "600519.SS",
                    MarketCap= 392630000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Mastercard",
                    Symbol= "MA",
                    MarketCap= 352760000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "UnitedHealth",
                    Symbol= "UNH",
                    MarketCap= 344790000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Procter &amp; Gamble",
                    Symbol= "PG",
                    MarketCap= 344140000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Nestlé",
                    Symbol= "NSRGY",
                    MarketCap= 333610000,
                    Country= "Switzerland",
                  },
                new RankModel {
                    Company= "NVIDIA",
                    Symbol= "NVDA",
                    MarketCap= 328730000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "LVMH",
                    Symbol= "LVMUY",
                    MarketCap= 327040000,
                    Country= "France",
                  },
                new RankModel {
                    Company= "Walt Disney",
                    Symbol= "DIS",
                    MarketCap= 322900000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Roche",
                    Symbol= "RHHBY",
                    MarketCap= 293520000,
                    Country= "Switzerland",
                  },
                new RankModel {
                    Company= "Home Depot",
                    Symbol= "HD",
                    MarketCap= 289700000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "PayPal",
                    Symbol= "PYPL",
                    MarketCap= 284080000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Bank of America",
                    Symbol= "BAC",
                    MarketCap= 281410000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "ICBC",
                    Symbol= "1398.HK",
                    MarketCap= 266230000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Meituan-Dianping",
                    Symbol= "MPNGF",
                    MarketCap= 246210000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Verizon",
                    Symbol= "VZ",
                    MarketCap= 239180000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Ping An Insurance",
                    Symbol= "PNGAY",
                    MarketCap= 237140000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Comcast",
                    Symbol= "CMCSA",
                    MarketCap= 235810000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Adobe",
                    Symbol= "ADBE",
                    MarketCap= 232710000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Nike",
                    Symbol= "NKE",
                    MarketCap= 230710000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Netflix",
                    Symbol= "NFLX",
                    MarketCap= 225490000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Pinduoduo",
                    Symbol= "PDD",
                    MarketCap= 221680000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Coca-Cola",
                    Symbol= "KO",
                    MarketCap= 219510000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Novartis",
                    Symbol= "NVS",
                    MarketCap= 214590000,
                    Country= "Switzerland",
                  },
                new RankModel {
                    Company= "Toyota",
                    Symbol= "TM",
                    MarketCap= 212390000,
                    Country= "Japan",
                  },
                new RankModel {
                    Company= "ASML",
                    Symbol= "ASML",
                    MarketCap= 212100000,
                    Country= "Netherlands",
                  },
                new RankModel {
                    Company= "Intel",
                    Symbol= "INTC",
                    MarketCap= 211660000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "L\" Oréal",
                    Symbol= "OR.PA",
                    MarketCap= 210160000,
                    Country= "France",
                  },
                new RankModel {
                    Company= "Merck",
                    Symbol= "MRK",
                    MarketCap= 210060000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "AT&amp;T",
                    Symbol= "T",
                    MarketCap= 206790000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Pfizer",
                    Symbol= "PFE",
                    MarketCap= 206380000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Salesforce",
                    Symbol= "CRM",
                    MarketCap= 203770000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Thermo Fisher Scientific",
                    Symbol= "TMO",
                    MarketCap= 203040000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Pepsico",
                    Symbol= "PEP",
                    MarketCap= 199250000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Abbott Laboratories",
                    Symbol= "ABT",
                    MarketCap= 197810000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "China Construction Bank",
                    Symbol= "CICHY",
                    MarketCap= 193710000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Exxon Mobil",
                    Symbol= "XOM",
                    MarketCap= 192210000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Oracle",
                    Symbol= "ORCL",
                    MarketCap= 190830000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Cisco",
                    Symbol= "CSCO",
                    MarketCap= 190400000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "AbbVie",
                    Symbol= "ABBV",
                    MarketCap= 189380000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "BHP Group",
                    Symbol= "BHP",
                    MarketCap= 186040000,
                    Country= "Australia",
                  },
                new RankModel {
                    Company= "Broadcom",
                    Symbol= "AVGO",
                    MarketCap= 181240000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "CM Bank",
                    Symbol= "3968.HK",
                    MarketCap= 180460000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "QUALCOMM",
                    Symbol= "QCOM",
                    MarketCap= 177150000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Reliance Industries",
                    Symbol= "RELIANCE.NS",
                    MarketCap= 177100000,
                    Country= "India",
                  },
                new RankModel {
                    Company= "Chevron",
                    Symbol= "CVX",
                    MarketCap= 175320000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Accenture",
                    Symbol= "ACN",
                    MarketCap= 175020000,
                    Country= "Ireland",
                  },
                new RankModel {
                    Company= "Danaher",
                    Symbol= "DHR",
                    MarketCap= 172960000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Agricultural Bank of China",
                    Symbol= "ACGBY",
                    MarketCap= 168730000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "T-Mobile US",
                    Symbol= "TMUS",
                    MarketCap= 167630000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Prosus",
                    Symbol= "PRX.VI",
                    MarketCap= 165690000,
                    Country= "Netherlands",
                  },
                new RankModel {
                    Company= "Costco",
                    Symbol= "COST",
                    MarketCap= 163860000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Novo Nordisk",
                    Symbol= "NVO",
                    MarketCap= 162260000,
                    Country= "Denmark",
                  },
                new RankModel {
                    Company= "Medtronic",
                    Symbol= "MDT",
                    MarketCap= 161130000,
                    Country= "Ireland",
                  },
                new RankModel {
                    Company= "McDonald",
                    Symbol= "MCD",
                    MarketCap= 160840000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Unilever",
                    Symbol= "UL",
                    MarketCap= 160420000,
                    Country= "Netherlands",
                  },
                new RankModel {
                    Company= "Eli Lilly",
                    Symbol= "LLY",
                    MarketCap= 159180000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Nextera Energy",
                    Symbol= "NEE",
                    MarketCap= 158930000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Texas Instruments",
                    Symbol= "TXN",
                    MarketCap= 157110000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "SAP",
                    Symbol= "SAP",
                    MarketCap= 156750000,
                    Country= "Germany",
                  },
                new RankModel {
                    Company= "Tata",
                    Symbol= "TCS.NS",
                    MarketCap= 156350000,
                    Country= "India",
                  },
                new RankModel {
                    Company= "Shell",
                    Symbol= "RYDAF",
                    MarketCap= 155950000,
                    Country= "Netherlands",
                  },
                new RankModel {
                    Company= "AIA",
                    Symbol= "AAIGF",
                    MarketCap= 153920000,
                    Country= "Hong Kong",
                  },
                new RankModel {
                    Company= "Union Pacific Corporation",
                    Symbol= "UNP",
                    MarketCap= 147450000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Honeywell",
                    Symbol= "HON",
                    MarketCap= 147370000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Jingdong Mall",
                    Symbol= "JD",
                    MarketCap= 146600000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Shopify",
                    Symbol= "SHOP",
                    MarketCap= 145120000,
                    Country= "Canada",
                  },
                new RankModel {
                    Company= "SoftBank",
                    Symbol= "SFTBF",
                    MarketCap= 143310000,
                    Country= "Japan",
                  },
                new RankModel {
                    Company= "China Life Insurance",
                    Symbol= "LFC",
                    MarketCap= 142650000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Linde",
                    Symbol= "LIN",
                    MarketCap= 141920000,
                    Country= "UK",
                  },
                new RankModel {
                    Company= "Anheuser-Busch Inbev",
                    Symbol= "BUD",
                    MarketCap= 141810000,
                    Country= "Belgium",
                  },
                new RankModel {
                    Company= "Bristol-Myers Squibb",
                    Symbol= "BMY",
                    MarketCap= 141210000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Amgen",
                    Symbol= "AMGN",
                    MarketCap= 138840000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Keyence",
                    Symbol= "KYCCF",
                    MarketCap= 137430000,
                    Country= "Japan",
                  },
                new RankModel {
                    Company= "Wells Fargo",
                    Symbol= "WFC",
                    MarketCap= 137220000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "United Parcel Service",
                    Symbol= "UPS",
                    MarketCap= 136910000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Morgan Stanley",
                    Symbol= "MS",
                    MarketCap= 136140000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Citigroup",
                    Symbol= "C",
                    MarketCap= 136090000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Astrazeneca",
                    Symbol= "AZN",
                    MarketCap= 135460000,
                    Country= "UK",
                  },
                new RankModel {
                    Company= "Bank of China",
                    Symbol= "BACHF",
                    MarketCap= 132660000,
                    Country= "China",
                  },
                new RankModel {
                    Company= "Philip Morris",
                    Symbol= "PM",
                    MarketCap= 129390000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Sony",
                    Symbol= "SNE",
                    MarketCap= 127620000,
                    Country= "Japan",
                  },
                new RankModel {
                    Company= "Charter Communications",
                    Symbol= "CHTR",
                    MarketCap= 126790000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "Starbucks",
                    Symbol= "SBUX",
                    MarketCap= 124020000,
                    Country= "USA",
                  },
                new RankModel {
                    Company= "NTT Docomo",
                    Symbol= "NTDMF",
                    MarketCap= 122470000,
                    Country= "Japan",
                  }
            };
            var redisClient = serviceScope.ServiceProvider.GetService<IConnectionMultiplexer>().GetDatabase();

            await redisClient.KeyDeleteAsync("*");

            for (var i = 0;i< ranks.Count; i++)
            {
                var rank = ranks[i];
                await redisClient.SortedSetAddAsync("REDIS_LEADERBOARD", rank.Symbol.ToLower(), rank.MarketCap);
                await redisClient.HashSetAsync(rank.Symbol.ToLower(), new HashEntry[]
                {
                  new HashEntry("company", rank.Company),
                  new HashEntry("country",rank.Country)
                });
            }
            
        }
    }
}

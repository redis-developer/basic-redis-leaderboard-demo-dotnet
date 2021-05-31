<div style="position: absolute; top: 0px; right: 0px;">
    <img width="200" height="200" src="https://redislabs.com/wp-content/uploads/2020/12/RedisLabs_Illustration_HomepageHero_v4.svg">
</div>

<div style="height: 150px"></div>

# Basic Redis Leaderboard Demo .Net Core 5

Show how the redis works with .Net Core 5.

![How it works](https://github.com/redis-developer/basic-redis-leaderboard-demo-dotnet/raw/master/docs/screenshot001.png)

# Overview video

Here's a short video that explains the project and how it uses Redis:

[![Watch the video on YouTube](https://github.com/redis-developer/basic-redis-leaderboard-demo-dotnet/raw/master/docs/YTThumbnail.png)](https://www.youtube.com/watch?v=zzinHxdZ34I)

# How it works?

## How the data is stored:

- The AAPL's details - market cap of 2,6 triillions and USA origin - are stored in a hash like below:
  - E.g `HSET "company:AAPL" symbol "AAPL" market_cap "2600000000000" country USA`
- The Ranks of AAPL of 2,6 trillions are stored in a <a href="https://redislabs.com/ebook/part-1-getting-started/chapter-1-getting-to-know-redis/1-2-what-redis-data-structures-look-like/1-2-5-sorted-sets-in-redis/">ZSET</a>.
  - E.g `ZADD companyLeaderboard 2600000000000 company:AAPL`

## How the data is accessed:

- Top 10 companies:
  - E.g `ZREVRANGE companyLeaderboard 0 9 WITHSCORES`
- All companies:
  - E.g `ZREVRANGE companyLeaderboard 0 -1 WITHSCORES`
- Bottom 10 companies:
  - E.g `ZRANGE companyLeaderboard 0 9 WITHSCORES`
- Between rank 10 and 15:
  - E.g `ZREVRANGE companyLeaderboard 9 14 WITHSCORES`
- Show ranks of AAPL, FB and TSLA:
  - E.g `ZSCORE companyLeaderBoard company:AAPL company:FB company:TSLA`
- Adding market cap to companies:
  - E.g `ZINCRBY companyLeaderBoard 1000000000 "company:FB"`
- Reducing market cap to companies:
  - E.g `ZINCRBY companyLeaderBoard -1000000000 "company:FB"`
- Companies over a Trillion:
  - E.g `ZCOUNT companyLeaderBoard 1000000000000 +inf`
- Companies between 500 billion and 1 trillion:
  - E.g `ZCOUNT companyLeaderBoard 500000000000 1000000000000`

### Code Example: Get top 10 companies

```C#
[HttpGet("top10")]
public IActionResult GetTop10()
{
    return Ok(rankService.Range(0, 9, true));
}
```

```C#
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
```

## How to run it locally?

### Development

```
git clone https://github.com/redis-developer/basic-redis-leaderboard-demo-dotnet.git
```

#### Write in environment variable or Dockerfile actual connection to Redis:

```
PORT = "API port"
REDIS_ENDPOINT_URL = "Redis server URI"
REDIS_PASSWORD = "Password to the server"
```

#### Run backend

```sh
dotnet run
```

#### Run frontend

```sh
cd BasicRedisLeaderboardDemoDotNetCore/ClientApp
yarn install
yarn serve
```

Static сontent runs automatically with the backend part. In case you need to run it separately, please see README in the [client](client) folder.

## Try it out

#### Deploy to Heroku

<p>
    <a href="https://heroku.com/deploy" target="_blank">
        <img src="https://www.herokucdn.com/deploy/button.svg" alt="Deploy to Heorku" />
    </a>
</p>

#### Deploy to Google Cloud

<p>
    <a href="https://deploy.cloud.run" target="_blank">
        <img src="https://deploy.cloud.run/button.svg" alt="Run on Google Cloud" width="150px"/>
    </a>
</p>

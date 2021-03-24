<div style="position: absolute; top: 0px; right: 0px;">
    <img width="200" height="200" src="https://redislabs.com/wp-content/uploads/2020/12/RedisLabs_Illustration_HomepageHero_v4.svg">
</div>

<div style="height: 150px"></div>

# Basic Redis Leaderboard Demo .Net Core 5

Show how the redis works with .Net Core 5.

![How it works](docs/screenshot001.png)

# How it works?
## 1. How the data is stored:
<ol>
    <li>The AAPL's details - market cap of 2,6 triillions and USA origin - are stored in a hash like below:
      <pre> <a href="https://redis.io/commands/hset">HSET</a> "company:AAPL" symbol "AAPL" market_cap "2600000000000" country USA</pre>
     </li>
    <li>The Ranks of AAPL of 2,6 trillions are stored in a <a href="https://redislabs.com/ebook/part-1-getting-started/chapter-1-getting-to-know-redis/1-2-what-redis-data-structures-look-like/1-2-5-sorted-sets-in-redis/">ZSET</a>. 
      <pre><a href="https://redis.io/commands/zadd">ZADD</a>  companyLeaderboard 2600000000000 company:AAPL</pre>
    </li>
</ol>

<br/>

## 2. How the data is accessed:
<ol>
    <li>Top 10 companies: <pre><a href="https://redis.io/commands/zrevrange">ZREVRANGE</a> companyLeaderboard 0 9 WITHSCORES</pre> </li>
    <li>All companies: <pre><a href="https://redis.io/commands/zrevrange">ZREVRANGE</a> companyLeaderboard 0 -1 WITHSCORES</pre> </li>
    <li>Bottom 10 companies: <pre><a href="https://redis.io/commands/zrange">ZRANGE</a> companyLeaderboard 0 9 WITHSCORES</pre></li>
    <li>Between rank 10 and 15: <pre><a href="https://redis.io/commands/zrevrange">ZREVRANGE</a> companyLeaderboard 9 14 WITHSCORES</pre></li>
    <li>Show ranks of AAPL, FB and TSLA: <pre><a href="https://redis.io/commands/zrevrange">ZREVRANGE</a>  companyLeaderBoard company:AAPL company:FB company:TSLA</pre> </li>
    <!-- <li>Pagination: Show 1st 10 companies: <pre><a href="https://redis.io/commands/zscan">ZSCAN</a> 0 companyLeaderBoard COUNT 10 7.Pagination: Show next 10 companies: ZSCAN &lt;return value from the 1st 10 companies&gt; companyLeaderBoard COUNT 10 </li> -->
    <li>Adding 1 billion to market cap of FB company: <pre><a href="https://redis.io/commands/zincrby">ZINCRBY</a> companyLeaderBoard 1000000000 "company:FB"</pre></li>
    <li>Reducing 1 billion of market cap of FB company: <pre><a href="https://redis.io/commands/zincrby">ZINCRBY</a> companyLeaderBoard -1000000000 "company:FB"</pre></li>
    <li>Companies between 500 billion and 1 trillion: <pre><a href="https://redis.io/commands/zcount">ZCOUNT</a> companyLeaderBoard 500000000000 1000000000000</pre></li>
    <li>Companies over a Trillion: <pre><a href="https://redis.io/commands/zcount">ZCOUNT</a> companyLeaderBoard 1000000000000 +inf</pre> </li>
</ol>


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

``` sh
dotnet run
```

#### Run frontend

Static сontent runs automatically with the backend part. In case you need to run it separately, please see README in the [client](client) folder.

## Try it out

#### Deploy to Heroku

<p>
    <a href="https://heroku.com/deploy" target="_blank">
        <img src="https://www.herokucdn.com/deploy/button.svg" alt="Deploy to Heorku" />
    </a>
</p>

#### Deploy to Vercel:

<p>

<a href="https://vercel.com/new/git/external?repository-url=https%3A%2F%2Fgithub.com%2Fredis-developer%2Fbasic-redis-leaderboard-demo-dotnet&env=REDIS_ENDPOINT_URL,REDIS_PASSWORD,PORT" target="_blank">
        <img src="https://vercel.com/button" alt="Deploy with Vercel" width="150px" height="41"/>
    </a>
</p>


#### Deploy to Google Cloud
<p>
    <a href="https://deploy.cloud.run" target="_blank">
        <img src="https://deploy.cloud.run/button.svg" alt="Run on Google Cloud" width="150px"/>
    </a>
</p>
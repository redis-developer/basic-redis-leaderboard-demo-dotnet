using BasicRedisLeaderboardDemoDotNetCore.BLL.DbContexts;
using BasicRedisLeaderboardDemoDotNetCore.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ServiceStack.Redis;
using System;
using System.IO;
using System.Reflection;

namespace BasicRedisLeaderboardDemoDotNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var redisEndpointUrl = (Environment.GetEnvironmentVariable("REDIS_ENDPOINT_URL") ?? "127.0.0.1:6379").Split(':');
            var redisHost = redisEndpointUrl[0];
            var redisPort = redisEndpointUrl[1];

            string redisConnectionUrl = string.Empty;
            var redisPassword = Environment.GetEnvironmentVariable("REDIS_PASSWORD");
            if (redisPassword != null)
            {
                redisConnectionUrl = $"{redisPassword}@{redisHost}:{redisPort}";
            }
            else
            {
                redisConnectionUrl = $"{redisHost}:{redisPort}";
            }

            var redisManager = new RedisManagerPool(redisConnectionUrl);
            var redis = redisManager.GetClient();
            services.AddSingleton(redis);

            Assembly.Load("BasicRedisLeaderboardDemoDotNetCore.BLL");
            ServiceAutoConfig.Configure(services);

            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.Map(new PathString(""), client =>
            {
                var clientPath = Path.Combine(Directory.GetCurrentDirectory(), "./ClientApp/dist");
                StaticFileOptions clientAppDist = new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(clientPath)
                };
                client.UseSpaStaticFiles(clientAppDist);
                client.UseSpa(spa => { spa.Options.DefaultPageStaticFileOptions = clientAppDist; });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
                });
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //Seed method
                AppDbInitializer.Seed(serviceScope);

            }
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Serilog;
using Serilog.Context;
using Summoner.Repository;
using Summoner.Service;

namespace SummonerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();

            services.AddTransient<IRiotApiConfigService, RiotApiConfigService>();
            services.AddTransient<IRiotApiClient, RiotApiClient>();
            services.AddTransient<IHttpResponseHandler, HttpResponseHandler>();
            services.AddTransient<IRiotApiUriService, RiotApiUriService>();
            services.AddTransient<IRiotApiSummonerRepository, RiotApiSummonerRepository>();
            services.AddTransient<ISummonerService, SummonerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();

            app.Use(async (httpContext, next) =>
            {
                if (httpContext.Request.Headers.TryGetValue("X-Correlation-Id", out var correlationId))
                {
                    LogContext.PushProperty("CorrelationId", correlationId.ToString());
                }

                await next.Invoke();
            });
            
//            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
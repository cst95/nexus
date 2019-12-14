using Microsoft.Extensions.DependencyInjection;
using Nexus.Utility.Interfaces;

namespace Nexus.Utility.Extensions
{
    public static class UtilityExtensions
    {
        public static void RegisterUtilityDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IApiKeyManager, ApiKeyManager>();
            serviceCollection.AddTransient<IHttpResponseHandler, HttpResponseHandler>();
            serviceCollection.AddTransient<IRiotApiConfigRepository, RiotApiConfigRepository>();
            serviceCollection.AddTransient<IUriBuilderService, UriBuilderService>();
        }
    }
}
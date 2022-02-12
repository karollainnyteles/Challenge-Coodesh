using Coodesh.Challenge.Business.Contracts.Services;
using Coodesh.Challenge.ClientHttp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Coodesh.Challenge.Api.Extensions
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddHttpClient<IArticleService, ArticleService>();

            return services;
        }
    }
}
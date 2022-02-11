using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Coodesh.Challenge.Api.Extensions
{
    public static class RepositoriesConfig
    {
        public static IServiceCollection AddRepositoriesConfig(this IServiceCollection services)
        {
            services.AddScoped<IArticleReadOnlyRepository, ArticleReadOnlyRepository>();
            services.AddScoped<IArticleWriteOnlyRepository, ArticleWriteOnlyRepository>();
            services.AddScoped<IEventWriteOnlyRepository, EventWriteOnlyRepository>();
            services.AddScoped<ILaunchWriteOnlyRepository, LaunchWriteOnlyRepository>();

            return services;
        }
    }
}
using Coodesh.Challenge.Api.Cron;
using Coodesh.Challenge.Api.Extensions;
using Coodesh.Challenge.Command.Commands.Articles.Create;
using Coodesh.Challenge.Command.Mappers;
using Coodesh.Challenge.Data.Context;
using Coodesh.Challenge.Query.Mappers;
using Coodesh.Challenge.Query.Queries.Articles.Find;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Coodesh.Challenge.Api
{
    public class Startup
    {
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers()
                .AddFluentValidation(a => a.RegisterValidatorsFromAssembly(typeof(CreateArticleCommandValidator).Assembly))
                .AddNewtonsoftJson(a => a.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwagger();

            services.AddRepositoriesConfig();
            services.AddServicesConfig();

            services.AddMediatR(typeof(FindArticlesQuery), typeof(CreateArticleCommand));

            services.AddAutoMapper(typeof(ArticleProfile), typeof(ArticleResponseProfile));

            services.AddHostedService<SynchronizationApiCron>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerConfig();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
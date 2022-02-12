using Coodesh.Challenge.Command.Commands.SynchronizationControls.SyncArticles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Api.Cron
{
    public class SynchronizationApiCron : IHostedService
    {
        private readonly ILogger<SynchronizationApiCron> _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public SynchronizationApiCron(ILogger<SynchronizationApiCron> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("start cron");
            var initialDelay = GetInitialDelay();
            var interval = TimeSpan.FromDays(1);
            _logger.LogInformation($"delay: {initialDelay}");
            _timer = new Timer(SyncArticles, null, initialDelay, interval);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("stop cron");
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async void SyncArticles(object state)
        {
            _logger.LogInformation("start Sync");

            using (var scoped = _serviceProvider.CreateScope())
            {
                var mediator = scoped.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(new SynchronizationControlCommand());
            }

            _logger.LogInformation("finish Sync");
        }

        private TimeSpan GetInitialDelay()
        {
            var currentDate = DateTime.Now;
            var executionDate = currentDate.Date.AddHours(9);
            //var executionDate = currentDate.AddSeconds(30);
            if (currentDate > executionDate)
            {
                executionDate = executionDate.AddDays(1);
            }

            return executionDate.Subtract(currentDate);
        }
    }
}
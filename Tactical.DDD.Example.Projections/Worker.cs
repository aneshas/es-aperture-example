using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Tactical.DDD.Example.Projections
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
    
    // public class Worker : IHostedService
    // {
    //     private readonly ApertureAgent _apertureAgent;
    //
    //     private readonly ILogger<Worker> _logger;
    //
    //     private readonly IHostApplicationLifetime _applicationLifetime;
    //
    //     public Worker(ApertureAgent apertureAgent, ILogger<Worker> logger, IHostApplicationLifetime applicationLifetime)
    //     {
    //         _apertureAgent = apertureAgent;
    //         _logger = logger;
    //         _applicationLifetime = applicationLifetime;
    //     }
    //
    //     public async Task StartAsync(CancellationToken cancellationToken)
    //     {
    //         try
    //         {
    //             await _apertureAgent
    //                 .UseRestartWithBackOffSupervision()
    //                 .UseLogger(_logger)
    //                 .UseCancellationToken(cancellationToken)
    //                 .StartAsync();
    //         }
    //         catch (Exception)
    //         {
    //             _applicationLifetime.StopApplication();
    //         }
    //     }
    //
    //     public Task StopAsync(CancellationToken cancellationToken)
    //     {
    //         _apertureAgent.Stop();
    //         return Task.CompletedTask;
    //     }
    // }
}
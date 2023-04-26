using Aperture.Core;
using Aperture.Polly;

namespace Bank24.ProjectionWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    private readonly ApertureAgent _apertureAgent;

    public Worker(ILogger<Worker> logger, ApertureAgent apertureAgent)
    {
        _logger = logger;
        _apertureAgent = apertureAgent;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _apertureAgent
            .UseRestartWithBackOffSupervision()
            .UseLogger(_logger)
            .UseCancellationToken(stoppingToken)
            .StartAsync();
    }
}
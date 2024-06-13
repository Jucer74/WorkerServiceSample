namespace WorkerService.App;

using Cronos;

public class Worker(ILogger<Worker> logger, IConfiguration configuration) : BackgroundService, IHostedLifecycleService
{
    private readonly ILogger<Worker> _logger = logger;

    private readonly IConfiguration _configuration = configuration;

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Started");
        return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting");
        return Task.CompletedTask;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start");
        return base.StartAsync(cancellationToken);
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopped");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping");
        return Task.CompletedTask;
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stop");
        return base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scheduleExpression = _configuration.GetSection("ScheduleExpression").Value!;
        CronExpression cronExpression = CronExpression.Parse(scheduleExpression);

        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.UtcNow;
            var next = cronExpression.GetNextOccurrence(now);

            var dt = next - now;

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(dt!.Value, stoppingToken);

            //await Task.Delay(1000, stoppingToken);
        }
    }
}
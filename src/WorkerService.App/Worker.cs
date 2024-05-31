namespace WorkerService.App;

using Cronos;

public class Worker(ILogger<Worker> logger, IConfiguration configuration) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;

    private readonly IConfiguration _configuration = configuration;

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
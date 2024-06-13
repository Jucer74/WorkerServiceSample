var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddWindowsService(options => options.ServiceName = "WorkerService");

var configuration = builder.Configuration
    .AddEnvironmentVariables()
    .Build();

var logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(configuration)
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .CreateBootstrapLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

Log.Logger = logger;
Log.Information("Starting Working Service");

var connectionString = configuration.GetConnectionString("DefaultConnection")!;
Log.Information(connectionString);
var scheduleExpression = configuration.GetSection("ScheduleExpression").Value!;
Log.Information(scheduleExpression);

host.Run();
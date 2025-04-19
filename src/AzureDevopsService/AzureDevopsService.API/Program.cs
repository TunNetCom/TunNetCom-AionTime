using AzureDevopsService.Application.Events.IntegrationEvents.Events.Incoming;
using AzureDevopsService.Application.Events.IntegrationEvents.EventsHandlers;
using AzureDevopsService.Infrasructure;
using TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    _ = builder.Logging.AddLoggingService();
    Log.Information("Starting web host");
    _ = builder.Services.AddOptions<RabbitMqSettings>().Bind(builder.Configuration.GetSection("RabbitMqSettings"));
    _ = builder.Services.AddMonitoringService();
    _ = builder.Services.AddApplicationService();
    _ = builder.Services.AddInfrasructureService(builder.Configuration);

    _ = builder.Services.AddEndpointsApiExplorer();
    _ = builder.Services.AddSwaggerGen();
    _ = builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
    _ = builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    _ = builder.Services.AddProblemDetails();
    _ = builder.Services.AddMediatR((conf) => { _ = conf.RegisterServicesFromAssembly(typeof(Program).Assembly); });
    WebApplication app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        _ = app.UseSwagger();
        _ = app.UseSwaggerUI();
    }

    _ = app.MapPrometheusScrapingEndpoint();
    app.AddEndpoints();

    _ = app.UseExceptionHandler();

    _ = app.UseHttpsRedirection();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
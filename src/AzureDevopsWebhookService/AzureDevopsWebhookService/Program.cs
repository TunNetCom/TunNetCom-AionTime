using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TunNetCom.AionTime.AzureDevops.WebhookService.API;
using TunNetCom.AionTime.AzureDevops.WebhookService.API.Middelware;
using TunNetCom.AionTime.AzureDevops.WebhookService.Application;
using TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.Settings;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.GrafanaLoki("http://loki:3100")
    .CreateBootstrapLogger();
try
{
    Log.Information("Starting web host");
    _ = builder.Logging.AddLoggingService();
    _ = builder.Services.AddOptions<RabbitMqSettings>().Bind(builder.Configuration.GetSection("RabbitMqSettings"));
    _ = builder.Services.AddMonitoringService();
    _ = builder.Services.AddAzureWebhookServiceRegistration();
    _ = builder.Services.AddControllers();
    _ = builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
    _ = builder.Services.AddEndpointsApiExplorer();
    _ = builder.Services.AddSwaggerGen();
    _ = builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

    WebApplication app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        _ = app.UseSwagger();
        _ = app.UseSwaggerUI();
    }

    _ = app.MapPrometheusScrapingEndpoint();
    _ = app.UseHttpsRedirection();

    _ = app.UseAuthorization();

    _ = app.MapControllers();

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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog.Events;
using Serilog.Sinks.Grafana.Loki;
using System.Runtime.CompilerServices;
using TunNetCom.AionTime.AzureDevopsService.API.Clients.Settings;
using TunNetCom.AionTime.AzureDevopsService.API.Data;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    _ = builder.Logging
    .AddOpenTelemetry(options =>
    {
        options.IncludeFormattedMessage = true;
        options.IncludeScopes = true;

        ResourceBuilder resBuilder = ResourceBuilder.CreateDefault();
        _ = resBuilder.AddService(typeof(Program).Assembly.GetName().Name ?? "AzureDevopsService");
        _ = options.SetResourceBuilder(resBuilder);

        _ = options.AddOtlpExporter();
    });
    _ = builder.Services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
    {
        // Filter out instrumentation of the Prometheus scraping endpoint.
        options.Filter = ctx => ctx.Request.Path != "/metrics";
    });

    _ = builder.Services.AddOpenTelemetry()
        .ConfigureResource(b =>
        {
            _ = b.AddService(typeof(Program).Assembly.GetName().Name ?? "AzureDevopsService");
        })
        .WithTracing(b => b
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddEntityFrameworkCoreInstrumentation()
            .AddSource(typeof(Program).Assembly.GetName().Name ?? "AzureDevopsService")
            .AddOtlpExporter())
        .WithMetrics(b => b
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddRuntimeInstrumentation()
            .AddProcessInstrumentation()
            .AddPrometheusExporter());

    Log.Information("Starting web host");
    _ = builder.Services.AddEndpointsApiExplorer();
    _ = builder.Services.AddSwaggerGen();
    _ = builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
    IConfigurationSection coreServerSettingsSection = builder.Configuration.GetSection(nameof(CoreServerSettings));
    _ = builder.Services.AddAzureDevOpsClients(coreServerSettingsSection);
    _ = builder.Services.AddScoped<IPatResolver, PatResolver>();
    _ = builder.Services.AddDbContext<AzureDevOpsContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
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
    app.AddTestEndpoints();

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
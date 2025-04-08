namespace TimeLogService.API;

public static class ExtentionServiceRegistration
{
    public static IServiceCollection AddMonitoringService(
   this IServiceCollection services)
    {
        _ = services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
        {
            // Filter out instrumentation of the Prometheus scraping endpoint.
            options.Filter = ctx => ctx.Request.Path != "/metrics";
        });

        _ = services.AddOpenTelemetry()
            .ConfigureResource(b =>
            {
                _ = b.AddService(typeof(Program).Assembly.GetName().Name ?? "TimeLogService");
            })
            .WithTracing(b => b
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddEntityFrameworkCoreInstrumentation()
            .AddSource(typeof(Program).Assembly.GetName().Name ?? "TimeLogService")
            .AddOtlpExporter())
            .WithMetrics(b => b
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddRuntimeInstrumentation()
            .AddProcessInstrumentation()
            .AddPrometheusExporter());

        return services;
    }

    public static ILoggingBuilder AddLoggingService(this ILoggingBuilder logging)
    {
        _ = logging.AddOpenTelemetry(options =>
        {
            options.IncludeFormattedMessage = true;
            options.IncludeScopes = true;

            ResourceBuilder resBuilder = ResourceBuilder.CreateDefault();
            _ = resBuilder.AddService(typeof(Program).Assembly.GetName().Name ?? "TimeLogService");
            _ = options.SetResourceBuilder(resBuilder);

            _ = options.AddOtlpExporter();
        });
        return logging;
    }
}
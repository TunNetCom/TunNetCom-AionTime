namespace TunNetCom.AionTime.TimeLogService.API;

public static class ExtentionService
{
    public static IServiceCollection AddExtensionServiceRegistration(
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
}
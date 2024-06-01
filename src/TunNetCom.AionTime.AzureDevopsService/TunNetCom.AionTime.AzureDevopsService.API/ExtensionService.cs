namespace TunNetCom.AionTime.AzureDevopsService.API;

public static class ExtensionService
{
    public static IServiceCollection AddExtensionService(this IServiceCollection services)
    {
        _ = services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
        {
            // Filter out instrumentation of the Prometheus scraping endpoint.
            options.Filter = ctx => ctx.Request.Path != "/metrics";
        });

        _ = services.AddOpenTelemetry()
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
        return services;
    }
}
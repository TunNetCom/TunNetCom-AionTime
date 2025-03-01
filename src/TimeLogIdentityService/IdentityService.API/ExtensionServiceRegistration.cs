namespace IdentityService.API;

public static class ExtensionServiceRegistration
{
    public static IServiceCollection AddMonitoringService(this IServiceCollection services)
    {
        _ = services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
        {
            // Filter out instrumentation of the Prometheus scraping endpoint.
            options.Filter = ctx => ctx.Request.Path != "/metrics";
        });

        _ = services.AddOpenTelemetry()
            .ConfigureResource(b =>
            {
                _ = b.AddService(typeof(Program).Assembly.GetName().Name ?? "AzureDevopsIdentityService");
            })
            .WithTracing(b => b
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddEntityFrameworkCoreInstrumentation()
                .AddSource(typeof(Program).Assembly.GetName().Name ?? "AzureDevopsIdentityService")
                .AddOtlpExporter())
            .WithMetrics(b => b
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddRuntimeInstrumentation()
                .AddProcessInstrumentation()
                .AddPrometheusExporter());

        return services;
    }

    public static ILoggingBuilder AddLoggingService(this ILoggingBuilder logger)
    {
        _ = logger.AddOpenTelemetry(options =>
        {
            options.IncludeFormattedMessage = true;
            options.IncludeScopes = true;
            ResourceBuilder resBuilder = ResourceBuilder.CreateDefault();
            _ = resBuilder.AddService(typeof(Program).Assembly.GetName().Name ?? "AzureDevopsIdentityService");
            _ = options.SetResourceBuilder(resBuilder);
            _ = options.AddOtlpExporter();
        });

        return logger;
    }
}
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
        _ = resBuilder.AddService(typeof(Program).Assembly.GetName().Name ?? "TimeLogService");
        _ = options.SetResourceBuilder(resBuilder);

        _ = options.AddOtlpExporter();
    });
    _ = builder.Services.AddExtensionServiceRegistration();
    _ = builder.Services.AddHttpContextAccessor();
    _ = builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
    _ = builder.Services.AddControllers();
    _ = builder.Services.AddInfrastructureServiceRegistration(builder.Configuration);
    _ = builder.Services.AddApplicationServices();
    _ = builder.Services.AddEndpointsApiExplorer();
    _ = builder.Services.AddSwaggerGen();
    _ = builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    _ = builder.Services.AddProblemDetails();

    WebApplication app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        using (IServiceScope scope = app.Services.CreateScope())
        {
            TunNetComAionTimeTimeLogServiceDataBaseContext dbContext = scope.ServiceProvider.GetRequiredService<TunNetComAionTimeTimeLogServiceDataBaseContext>();
            _ = dbContext.Database.EnsureCreated();
        }

        _ = app.UseSwagger();
        _ = app.UseSwaggerUI();
    }

    _ = app.MapPrometheusScrapingEndpoint();
    _ = app.UseHttpsRedirection();
    _ = app.UseExceptionHandler();
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
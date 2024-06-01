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
    _ = builder.Services.AddMonitoringService();
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
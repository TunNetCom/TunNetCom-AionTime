#pragma warning disable CS8604 // Possible null reference argument.
using IdentityService.API.Middelware;
using RabbitMQ.Client;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.GrafanaLoki("http://loki:3100")
    .CreateBootstrapLogger();

try
{
    string[]? allowedOrigins = builder.Configuration.GetSection("AllowedOrigin").Get<string[]>();
    Log.Information("Starting web host");
    _ = builder.Services.AddOptions<RabbitMqSettings>().Bind(builder.Configuration.GetSection("RabbitMqSettings"));
    _ = builder.Logging.AddLoggingService();
    _ = builder.Services.AddMonitoringService();
    _ = builder.Services.AddControllers();
    _ = builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
    _ = builder.Services.AddApplicationServices();
    _ = builder.Services.AddEndpointsApiExplorer();
    _ = builder.Services.AddSwaggerGen();
    _ = builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
    Console.WriteLine(typeof(ConnectionFactory).Assembly.Location);
    Console.WriteLine(typeof(ConnectionFactory).Assembly.FullName);
    _ = builder.Services.AddCors(options =>
    {
        options.AddPolicy(
            "AllowSpecificOrigin",
            builder => builder.WithOrigins(allowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod());
    });

    _ = builder.Services.AddIdentityServicesRegistration(builder.Configuration);
    _ = builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

    WebApplication app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        using (IServiceScope scope = app.Services.CreateScope())
        {
            AuthContext dbContext = scope.ServiceProvider.GetRequiredService<AuthContext>();
            _ = dbContext.Database.EnsureCreated();
        }

        _ = app.UseSwagger();
        _ = app.UseSwaggerUI();
    }

    _ = app.MapPrometheusScrapingEndpoint();
    _ = app.UseHttpsRedirection();
    _ = app.UseCors("AllowSpecificOrigin");
    _ = app.UseAuthorization();
    _ = app.MapControllers();
    app.AddEndpoints();

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
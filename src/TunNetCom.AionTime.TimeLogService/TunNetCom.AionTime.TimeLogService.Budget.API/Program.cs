using TunNetCom.AionTime.TimeLogService.API.Middelware;
using TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddControllers();
builder.Services.AddInfrastructureServiceRegistration(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (IServiceScope scope = app.Services.CreateScope())
    {
        TunNetComAionTimeTimeLogServiceDataBaseContext dbContext = scope.ServiceProvider.GetRequiredService<TunNetComAionTimeTimeLogServiceDataBaseContext>();
        dbContext.Database.EnsureCreated();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();

app.MapControllers();

app.Run();
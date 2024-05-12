using Microsoft.EntityFrameworkCore;
using TunNetCom.AionTime.AzureDevopsService.API.Clients.Settings;
using TunNetCom.AionTime.AzureDevopsService.API.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
IConfigurationSection coreServerSettingsSection = builder.Configuration.GetSection(nameof(CoreServerSettings));
builder.Services.AddAzureDevOpsClients(coreServerSettingsSection);
builder.Services.AddScoped<IPatResolver, PatResolver>();
builder.Services.AddDbContext<AzureDevOpsContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddMediatR((conf) => { _ = conf.RegisterServicesFromAssembly(typeof(Program).Assembly); });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.AddTestEndpoints();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.Run();
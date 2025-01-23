#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Infrastructure;

public static class IdentityServicesRegistration
{
    private const string Secret = "JWT:Secret";
    private const string ValidAudience = "JWT:ValidAudience";
    private const string ValidIssuer = "JWT:ValidIssuer";
    private const string ConnectionStringDocker = "IdentityContextDocker";
    private const string ConnectionString = "IdentityContext";
    private const string ContainerRunning = "DOTNET_RUNNING_IN_CONTAINER";

    public static IServiceCollection AddIdentityServicesRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        bool isDocker = Environment.GetEnvironmentVariable(ContainerRunning) == "true";
        string? connection = isDocker
           ? configuration.GetConnectionString(ConnectionStringDocker)
           : configuration.GetConnectionString(ConnectionString);
        _ = services.AddDbContext<AuthContext>(options =>
        {
            _ = options.UseSqlServer(
                connection,
                sqlServerOptionsAction: sqlOptions =>
                {
                    _ = sqlOptions.EnableRetryOnFailure();
                });

            _ = options.EnableSensitiveDataLogging();
        });

        _ = services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();

        _ = services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration[ValidAudience],
            ValidIssuer = configuration[ValidIssuer],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[Secret] ?? string.Empty)),
        };
    });
        return services;
    }
}
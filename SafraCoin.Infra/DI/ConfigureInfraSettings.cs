using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafraCoin.Infra.Settings;

namespace SafraCoin.Infra.DI;

public static class ConfigureInfraSettings
{
    public static IServiceCollection AddInfraSettings(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
        services.Configure<RedisSettings>(configuration.GetSection("Redis"));
        return services;
    }
}

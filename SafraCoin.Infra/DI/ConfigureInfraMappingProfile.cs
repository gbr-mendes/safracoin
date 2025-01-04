using Microsoft.Extensions.DependencyInjection;
using SafraCoin.Infra.Mapping;

namespace SafraCoin.Infra.DI;

public static class ConfigureInfraMappingProfile
{
    public static IServiceCollection AddInfraMappingProfile(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(InfraProfile));
        return services;
    }
}

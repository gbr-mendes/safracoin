using SafraCoin.Mapping;

namespace SafraCoin.DI;

public static class ConfigureMapperProfile
{
    public static IServiceCollection AddPresentationMapperProfile(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PresentationProfile));
        return services;
    }
}

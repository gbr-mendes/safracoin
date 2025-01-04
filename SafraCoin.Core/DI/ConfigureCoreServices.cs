using Microsoft.Extensions.DependencyInjection;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.Services;

namespace SafraCoin.Core.DI;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IInvestorService, InvestorService>();
        services.AddScoped<IFarmerService, FarmerService>();
        return services;
    }
}

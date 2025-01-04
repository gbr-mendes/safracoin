using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SafraCoin.Core.Interfaces.Repositories;
using SafraCoin.Core.Interfaces.Repositories.EFRepository;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.Models;
using SafraCoin.Infra.AutoMapping;
using SafraCoin.Infra.Db;
using SafraCoin.Infra.Repositories;
using SafraCoin.Infra.Repositories.EFRepository;
using SafraCoin.Infra.Services;
using SafraCoin.Infra.Settings;
using StackExchange.Redis;

namespace SafraCoin.Infra.DI;

public static class ConfigureInfraServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.AddScoped<IProtoService, ProtoService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRedisRepository, RedisRepository>();
        services.AddScoped<IFarmerRepository, FarmerRepository>();
        services.AddScoped<IInvestorRepository, InvestorRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly("SafraCoin")));
        

        services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
            return ConnectionMultiplexer.Connect(redisSettings.ConnectionString);
        });
        
        services.AddAutoMapper(typeof(SafraCoinProfile));

        return services;
    }
}

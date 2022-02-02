using CloudLabs.Quantum.API.BackgroundTasks;
using CloudLabs.Quantum.API.Configuration.CosmosDb;
using CloudLabs.Quantum.API.Repositories;
using CloudLabs.Quantum.API.Services;
using MediatR;
using StackExchange.Redis;

namespace CloudLabs.Quantum.API.Configuration;

public static class ApplicationInstaller
{
    public static IServiceCollection InstallApplicationTools(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.InstallCosmosDb(configuration);
        services.AddMediatR(typeof(Program));
        services.AddScoped<ICacheService, RedisCacheService>();
        services.AddScoped<ICoinService, CoinService>();
        services.AddScoped<ICoinRepository, CoinRepository>();
        services.AddSingleton<IConnectionMultiplexer>(x =>
            ConnectionMultiplexer.Connect(configuration.GetValue<string>("RedisConnection")));
        services.AddHostedService<RedisSubscriber>();
        return services;
    }
}
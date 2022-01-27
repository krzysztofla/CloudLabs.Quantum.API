using CloudLabs.Quantum.API.Configuration.CosmosDb.ModelBinding;
using CloudLabs.Quantum.API.Settings;
using Microsoft.EntityFrameworkCore;

namespace CloudLabs.Quantum.API.Configuration.CosmosDb;

public static class InstallerExtension
{
    public static IServiceCollection InstallCosmosDb(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var settings = new CosmosDbSettings();

        configuration.GetSection("CosmosDb").Bind(settings);
        serviceCollection.AddDbContext<CoinContext>(c => c.UseCosmos(
            settings.AccountEndpoint, settings.AccountKey, settings.DatabaseName
        ));
        return serviceCollection;
    }
}
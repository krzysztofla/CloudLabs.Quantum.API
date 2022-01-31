using Bogus;
using CloudLabs.Quantum.API.Entities;
using CloudLabs.Quantum.API.ValueObjects;

namespace CloudLabs.Quantum.API.Configuration.CosmosDb.DataInitializer;

public static class FakeData 
{
    public static List<Coin> InitializeData(int count)
    {
        var fakeCoinPrice = new Faker<Price>()
            .RuleFor(p => p.Value, x => x.Finance.Amount(0, 1000))
            .RuleFor(p => p.CreatedAt, _ => DateTime.UtcNow.AddMinutes(10));

        var fakeCoins = new Faker<Coin>()
            .RuleFor(p => p.id, _ => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Hacker.Noun())
            .RuleFor(p => p.Description, f => f.Finance.Random.Words())
            .RuleFor(p => p.CoinType, f => f.Finance.Random.Enum<CoinType>())
            .RuleFor(p => p.PriceHistory, (f, p) =>
            {
                var price = fakeCoinPrice.Generate(count);
                return price;
            });

        var coins = fakeCoins.Generate(count);



        return coins;
    }
}
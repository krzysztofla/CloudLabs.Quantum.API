using CloudLabs.Quantum.API.ValueObjects;

namespace CloudLabs.Quantum.API.Entities;

public class Coin
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "tbd";

    public Price LatestPrice { get; set; } = new(0, DateTime.UtcNow);

    public List<Price> PriceHistory { get; set; } = new();

    public DateTime UpdatedAt { get; set; }

    public CoinType CoinType { get; set; }
}


using CloudLabs.Quantum.API.ValueObjects;
using Newtonsoft.Json;

namespace CloudLabs.Quantum.API.Entities;

public class Coin
{
    public Guid id { get; set; }

    public string Name { get; set; } = "tbd";

    public string Description { get; set; } = "tbd";

    public Price LatestPrice { get; set; } = new(0, DateTime.UtcNow);

    public List<Price> PriceHistory { get; set; } = new();

    public DateTime UpdatedAt { get; set; }

    public CoinType CoinType { get; set; }
}


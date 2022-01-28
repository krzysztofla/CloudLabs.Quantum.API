using CloudLabs.Quantum.API.ValueObjects;

namespace CloudLabs.Quantum.API.Dto;

public class CoinDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "tbd";

    public string Description { get; set; } = "tbd";
    
    public string CoinType { get; set; }
}
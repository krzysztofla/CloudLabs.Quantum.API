using CloudLabs.Quantum.API.Entities;
using CloudLabs.Quantum.API.ValueObjects;

namespace CloudLabs.Quantum.API.Services;

public interface ICoinService
{
    Task<Coin> GetCoin(Guid guid);
    Task<Coin> UpdateCoin(Coin coin);
    Task RemoveCoin(Guid guid);
    Task<List<Price>> GetPriceHistory(Guid guid);
}
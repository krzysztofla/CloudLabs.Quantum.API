using CloudLabs.Quantum.API.Dto;
using CloudLabs.Quantum.API.Entities;
using CloudLabs.Quantum.API.ValueObjects;

namespace CloudLabs.Quantum.API.Services;

public interface ICoinService
{
    Task<Coin> GetCoin(Guid guid);
    Task UpdateCoin(CoinDto coin);
    Task AddCoin(CoinDto coin);
    Task RemoveCoin(CoinDto guid);
    Task AddPrice(Guid id, Price price);
}
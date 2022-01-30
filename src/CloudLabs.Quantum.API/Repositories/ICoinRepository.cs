using CloudLabs.Quantum.API.Entities;

namespace CloudLabs.Quantum.API.Repositories;

public interface ICoinRepository
{
    Task<Coin> GetCoin(Guid guid);
    Task UpdateCoin(Coin coin);
    Task AddCoin(Coin coin);
    Task AddRange(List<Coin> coins);
    Task RemoveCoin(Coin guid);
    
    Task AddPrice(Coin price);
}
using CloudLabs.Quantum.API.Configuration.CosmosDb.DataInitializer;
using CloudLabs.Quantum.API.Configuration.CosmosDb.ModelBinding;
using CloudLabs.Quantum.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudLabs.Quantum.API.Repositories;

public class CoinRepository : ICoinRepository
{
    private readonly DbSet<Coin> _coins;
    private readonly CoinContext _context;

    public CoinRepository(CoinContext context)
    {
        _context = context;
        _coins = context.Coins;
    }

    public async Task<Coin> GetCoin(Guid guid)
    {
        var coin = await _context.Coins.SingleOrDefaultAsync(i => i.id == guid);
        if (coin is null)
        {
            throw new Exception();
        }

        return coin;
    }

    public async Task UpdateCoin(Coin coin)
    {
        _coins.Update(coin);
        await _context.SaveChangesAsync();
    }

    public async Task AddCoin(Coin coin)
    {
        await _coins.AddAsync(coin);
        await _context.SaveChangesAsync();
    }

    public async Task AddRange(List<Coin> coins)
    {
        await _coins.AddRangeAsync(coins);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveCoin(Coin coin)
    {
        _coins.Remove(coin);
        await _context.SaveChangesAsync();
    }

    public async Task AddPrice(Coin coin)
    {
        _coins.Update(coin);
        await _context.SaveChangesAsync();
    }
}
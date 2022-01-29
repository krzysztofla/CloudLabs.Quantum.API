using CloudLabs.Quantum.API.Configuration.CosmosDb.ModelBinding;
using CloudLabs.Quantum.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudLabs.Quantum.API.Configuration.CosmosDb.DataInitializer;

public class FakeDataInitializer : IFakeDataInitializer
{
    private readonly DbSet<Coin> _coins;
    private readonly CoinContext _context;

    internal FakeDataInitializer(CoinContext context)
    {
        _context = context.;
    }
    
    public void InitializeData()
    {
        _coins.Add(new Coin());
    }
}

public interface IFakeDataInitializer
{
    void InitializeData();
}
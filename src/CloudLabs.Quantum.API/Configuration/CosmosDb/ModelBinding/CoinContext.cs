using CloudLabs.Quantum.API.Entities;
using CloudLabs.Quantum.API.Settings;
using Microsoft.EntityFrameworkCore;

namespace CloudLabs.Quantum.API.Configuration.CosmosDb.ModelBinding;

public class CoinContext : DbContext
{
    public DbSet<Coin> Coins { get; set; }

    public CoinContext(DbContextOptions<CoinContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultContainer("Coins");
        modelBuilder.Entity<Coin>()
            .HasPartitionKey(c => c.id);
    }
}
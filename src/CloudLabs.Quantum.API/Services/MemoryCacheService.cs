using Microsoft.Extensions.Caching.Memory;

namespace CloudLabs.Quantum.API.Services;

public class MemoryCacheService : ICacheService
{
    private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    
    public Task<string> GetCachedDataAsync(string key)
    {
        return Task.FromResult(_cache.Get<string>(key));
    }

    public Task SetCacheDataAsync(string key, string value)
    {
        _cache.Set(key, value);
        return Task.CompletedTask;
    }
}
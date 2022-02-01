namespace CloudLabs.Quantum.API.Services;

public interface IInMemoryCacheService
{
    Task<string> GetCachedDataAsync(string key);
    Task SetCacheDataAsync(string key, string value);
}
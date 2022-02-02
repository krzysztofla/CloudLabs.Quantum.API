namespace CloudLabs.Quantum.API.Services;

public interface ICacheService
{
    Task<string> GetCachedDataAsync(string key);
    Task SetCacheDataAsync(string key, string value);
}
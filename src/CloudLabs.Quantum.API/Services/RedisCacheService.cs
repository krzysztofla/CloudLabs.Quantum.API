using StackExchange.Redis;

namespace CloudLabs.Quantum.API.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _multiplexer;

        public RedisCacheService(IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
        }

        public async Task<string> GetCachedDataAsync(string key)
        {
            var db = _multiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetCacheDataAsync(string key, string value)
        {
            var db = _multiplexer.GetDatabase();
            await db.StringSetAsync(key, value);
        }
    }
}
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace RedisBlazorDemo.Extensions
{
    public static class DistributedCacheExtension
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordId,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);       // 
            options.SlidingExpiration = unusedExpireTime;   // even if the absoluteExpireTime hasn't been met the cache would update anyway after slidingExpiration, not that important

            var jsonData = JsonSerializer.Serialize(data);      // take the data and serialize it into json
            await cache.SetStringAsync(recordId, jsonData, options);

        }


        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);        // get data that belongs to key = recordId

            if(jsonData is null)
            {
                return default(T);  // generic way of return null-values
            }

            return JsonSerializer.Deserialize<T>(jsonData);     // Takes the jsonData and serialize it into object-model T

        }

    }
}

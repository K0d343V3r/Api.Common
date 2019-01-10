using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Common.Cache
{
    public class RedisEntityCache<T> : IEntityCache<T>
    {
        private readonly IDistributedCache _cache;

        public RedisEntityCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetEntityAsync(string prefix, string key)
        {
            string entityString = await _cache.GetStringAsync(GetCacheKey(prefix, key));
            if (string.IsNullOrEmpty(entityString))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(entityString);
            }
        }

        public async Task SetEntityAsync(string prefix, string key, T entity)
        {
            await SetEntityAsyncInternal(prefix, key, entity, null);
        }

        public async Task SetEntityAsync(string prefix, string key, T entity, TimeSpan? expirationFromNow)
        {
            await SetEntityAsyncInternal(prefix, key, entity, expirationFromNow);
        }

        private async Task SetEntityAsyncInternal(string prefix, string key, T entity, TimeSpan? expirationFromNow)
        {
            await _cache.SetStringAsync(
                 GetCacheKey(prefix, key),
                 JsonConvert.SerializeObject(entity),
                 new DistributedCacheEntryOptions()
                 {
                     AbsoluteExpirationRelativeToNow = expirationFromNow
                 }
             );
        }

        public async Task InvalidateEntityAsync(string prefix, string key)
        {
            await _cache.RemoveAsync(GetCacheKey(prefix, key));
        }

        private string GetCacheKey(string prefix, string key)
        {
            return $"{prefix}-{key}";
        }
    }
}

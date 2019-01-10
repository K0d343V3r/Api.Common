using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Common.Cache
{
    public interface IEntityCache<T>
    {
        Task<T> GetEntityAsync(string prefix, string key);
        Task SetEntityAsync(string prefix, string key, T entity);
        Task SetEntityAsync(string prefix, string key, T entity, TimeSpan? expirationFromNow);
        Task InvalidateEntityAsync(string prefix, string key);
    }
}

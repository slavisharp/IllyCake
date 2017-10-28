namespace IllyCake.Common.Services
{
    using Microsoft.Extensions.Caching.Memory;
    using System;

    public interface ICacheService
    {
        void CacheObject<T>(string itemKey, T itemData, int durationInSeconds);

        T Get<T>(string itemName, Func<ICacheEntry, T> getDataFunc, int durationInSeconds);

        bool IsCached(string itemName);

        void Remove(string itemName);
    }
}

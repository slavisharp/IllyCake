namespace IllyCake.Common.Services
{
    using Microsoft.Extensions.Caching.Memory;
    using System;

    public class MemoryCacheService : ICacheService
    {
        private IMemoryCache memory;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            this.memory = memoryCache;
        }

        public void CacheObject<T>(string itemKey, T itemData, int durationInSeconds)
        {
            this.Remove(itemKey);
            this.memory.Set(itemKey, itemData, new DateTimeOffset(DateTime.Now.AddSeconds(durationInSeconds)));
        }

        public T Get<T>(string itemName, Func<ICacheEntry, T> getDataFunc, int durationInSeconds)
        {
            var data = this.memory.GetOrCreate(key: itemName, factory: getDataFunc);
            return data;
        }

        public bool IsCached(string itemName)
        {
            object value;
            return this.memory.TryGetValue(itemName, out value);
        }

        public void Remove(string itemName)
        {
            this.memory.Remove(itemName);
        }
    }
}

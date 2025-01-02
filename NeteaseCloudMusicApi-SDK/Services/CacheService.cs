using System.Collections.Concurrent;

namespace NeteaseCloudMusicApi_SDK.Services
{
    public class CacheService
    {
        private readonly ConcurrentDictionary<string, CacheEntry> _cache;
        private readonly Timer _cleanupTimer;

        public CacheService()
        {
            _cache = new ConcurrentDictionary<string, CacheEntry>();
            _cleanupTimer = new Timer(CleanupExpiredEntries, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        /// <summary>
        /// Adds an item to the cache.
        /// </summary>
        /// <param name="key">The unique cache key.</param>
        /// <param name="value">The value to cache.</param>
        /// <param name="duration">The cache duration.</param>
        public void Add(string key, object value, TimeSpan duration)
        {
            var expiration = DateTime.UtcNow.Add(duration);
            var entry = new CacheEntry(value, expiration);
            _cache[key] = entry;
        }

        /// <summary>
        /// Removes an item from the cache.
        /// </summary>
        /// <param name="key">The unique cache key.</param>
        public void Remove(string key)
        {
            _cache.TryRemove(key, out _);
        }

        /// <summary>
        /// Gets a cached item.
        /// </summary>
        /// <param name="key">The unique cache key.</param>
        /// <returns>The cached value, or null if not found or expired.</returns>
        public object Get(string key)
        {
            if (_cache.TryGetValue(key, out var entry))
            {
                if (entry.Expiration > DateTime.UtcNow)
                {
                    return entry.Value;
                }

                // Remove expired entry
                _cache.TryRemove(key, out _);
            }

            return null;
        }

        /// <summary>
        /// Clears all cache entries.
        /// </summary>
        public void Clear()
        {
            _cache.Clear();
        }

        /// <summary>
        /// Periodically cleans up expired cache entries.
        /// </summary>
        /// <param name="state">State object (not used).</param>
        private void CleanupExpiredEntries(object state)
        {
            var expiredKeys = _cache
                .Where(kvp => kvp.Value.Expiration <= DateTime.UtcNow)
                .Select(kvp => kvp.Key)
                .ToList();

            foreach (var key in expiredKeys)
            {
                _cache.TryRemove(key, out _);
            }
        }

        /// <summary>
        /// Gets the current cache size.
        /// </summary>
        public int Size => _cache.Count;

        private class CacheEntry
        {
            public object Value { get; }
            public DateTime Expiration { get; }

            public CacheEntry(object value, DateTime expiration)
            {
                Value = value;
                Expiration = expiration;
            }
        }
    }

}

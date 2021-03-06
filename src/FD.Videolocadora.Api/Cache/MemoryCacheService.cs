﻿using System;
using System.Runtime.Caching;

namespace FD.Videolocadora.Api.Cache
{
    public class MemoryCacheService : ICache
    {

        private readonly MemoryCache _memoryCache;
        public MemoryCacheService()
        {
            _memoryCache = MemoryCache.Default;
        }

        public void SetCache(string key, object value)
        {
            _memoryCache.Add(key, value, DateTimeOffset.Now.AddHours(1));
        }

        public object GetCache(string key)
        {
            return _memoryCache.Get(key);
        }
    }
}
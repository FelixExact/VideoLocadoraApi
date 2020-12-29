using StackExchange.Redis;
using System;
using System.Configuration;
using Newtonsoft.Json;
using FD.Videolocadora.Domain.Helper;

namespace FD.Videolocadora.Api.Cache
{
    public class RedisService : ICache
    {
        private IDatabase _redisCache;
        private Lazy<ConnectionMultiplexer> _ConnFactory;
        private Lazy<ConnectionMultiplexer> GetConnFactory()
        {
            if (_ConnFactory == null)
            {
                _ConnFactory = new Lazy<ConnectionMultiplexer>(() =>
                {
                    return ConnectionMultiplexer.Connect(_CONNSTRINGREDIS);
                });
            }
            return _ConnFactory;
        }
        private IDatabase GetRedisCache()
        {
            if (_redisCache == null)
            {
                _redisCache = GetConnFactory().Value.GetDatabase(_REDIS_DB_INDEX);
            }
            return _redisCache;
        }
        private string _CONNSTRINGREDIS;
        private const int _REDIS_DB_INDEX = 10;

        public RedisService()
        {
            _CONNSTRINGREDIS = ConfigurationManager.AppSettings["REDIS_CONNECTION_STRING"];
        }

        public void SetCache(string key, object value)
        {
            var valueString = VideoLocadoraHelperToJson.ToJson(value);
            GetRedisCache().StringSet(key, valueString);
        }

        public object GetCache(string key)
        {
            return GetRedisCache().StringGet(key);
        }


     
    }
}
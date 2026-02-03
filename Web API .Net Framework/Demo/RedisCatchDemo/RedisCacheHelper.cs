using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisCatchDemo
{
    public class RedisCacheHelper
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string redisConnection = "localhost:6379";
            return ConnectionMultiplexer.Connect(redisConnection);
        });

        // Expose the connection as a singleton
        public static ConnectionMultiplexer Connection => lazyConnection.Value;

        // Get Redis database (default db is 0)
        public static IDatabase GetDatabase()
        {
            return Connection.GetDatabase();
        }
    }
}
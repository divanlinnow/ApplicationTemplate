using ApplicationFramework.Logging;
using StackExchange.Redis;
using System.Configuration;
using System.Net;

namespace ApplicationFramework.Caching
{
    public class RedisConnectionWrapper : IRedisConnectionWrapper
    {
        private readonly IRedisServerSettings settings;
        private readonly ILogger logger;
        private readonly string connectionString;

        private volatile ConnectionMultiplexer connection;
        private readonly object _lock = new object();

        public RedisConnectionWrapper(ILogger logger)
        {
            this.settings = ConfigurationManager.GetSection("redis") as RedisServerSettings;
            this.logger = logger;
            this.connectionString = GetConnectionString();
        }

        private string GetConnectionString()
        {
            var con = ConfigurationManager.ConnectionStrings[settings.ConnectionStringOrName];

            return con == null ? settings.ConnectionStringOrName : con.ConnectionString;
        }

        private ConnectionMultiplexer GetConnection()
        {
            if (connection != null && connection.IsConnected) return connection;

            lock (_lock)
            {
                if (connection != null && connection.IsConnected) return connection;

                if (connection != null)
                {
                    logger.Info("Connection disconnected. Disposing connection...");
                    connection.Dispose();
                }

                logger.Info("Creating new instance of Redis Connection");
                connection = ConnectionMultiplexer.Connect(connectionString);
            }

            return connection;
        }

        public IDatabase Database(int? db = null)
        {
            return GetConnection().GetDatabase(db ?? settings.DefaultDb);
        }

        public IServer Server(EndPoint endPoint)
        {
            return GetConnection().GetServer(endPoint);
        }

        public EndPoint[] GetEndpoints()
        {
            return GetConnection().GetEndPoints();
        }

        public void FlushDb(int? db = null)
        {
            var endPoints = GetEndpoints();

            foreach (var endPoint in endPoints)
            {
                Server(endPoint).FlushDatabase(db ?? settings.DefaultDb);
            }
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
            }
        }
    }
}

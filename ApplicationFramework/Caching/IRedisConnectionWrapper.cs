﻿using StackExchange.Redis;
using System;
using System.Net;

namespace ApplicationFramework.Caching
{
    public interface IRedisConnectionWrapper : IDisposable
    {
        IDatabase Database(int? db = null);

        IServer Server(EndPoint endPoint);

        EndPoint[] GetEndpoints();

        void FlushDb(int? db = null);
    }
}

﻿using StackExchange.Redis;

namespace MarketPlaceIntegration.Services.N11.Services;
public class RedisService
{
    private readonly string _host;

    private readonly int _port;

    private ConnectionMultiplexer _ConnectionMultiplexer;

    public RedisService(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public void Connect() => _ConnectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

    public IDatabase GetDb(int db = 1) => _ConnectionMultiplexer.GetDatabase(db);
}

using StackExchange.Redis;

public static class RedisDB
{
    private static readonly Lazy<ConnectionMultiplexer> _lazyConnection;
    public static ConnectionMultiplexer Connection
    {
        get
        {
            return _lazyConnection.Value;
        }
    }

    static RedisDB()
    {
        _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            ConnectionMultiplexer.Connect("localhost")
        );
    }
}

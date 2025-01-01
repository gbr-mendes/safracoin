using SafraCoin.Core.Interfaces.Repositories;
using StackExchange.Redis;

namespace SafraCoin.Infra.Repositories;

public class RedisRepository : IRedisRepository
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;
    public RedisRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = _redis.GetDatabase();
    }
}

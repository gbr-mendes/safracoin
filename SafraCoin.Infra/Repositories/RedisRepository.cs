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

    public async Task<bool> AddEntryToStreamAsync(string streamKey, byte[] entry)
    {
        var streamEntry = new NameValueEntry[]
        {
            new("entry", entry)
        };

        var entryId = await _database.StreamAddAsync(streamKey, streamEntry);

        return !string.IsNullOrEmpty(entryId);
    }
}

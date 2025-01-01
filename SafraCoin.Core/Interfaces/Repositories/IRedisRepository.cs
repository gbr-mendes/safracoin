namespace SafraCoin.Core.Interfaces.Repositories;

public interface IRedisRepository
{
    Task<bool> AddEntryToStreamAsync(string streamKey, byte[] entry);
}

using SafraCoin.Core.Models;

namespace SafraCoin.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<bool> UserExists(string email);
    Task<bool> AddUser(User user);
}

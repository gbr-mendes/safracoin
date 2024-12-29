using SafraCoin.Core.DTO.Authentication;
using SafraCoin.Core.Models;

namespace SafraCoin.Core.Interfaces.Services;

public interface IAuthService
{
    string GenerateToken(User user);
    bool IsPasswordValid(string passwordHash, string password);
}

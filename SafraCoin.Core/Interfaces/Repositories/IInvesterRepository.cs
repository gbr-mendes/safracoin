using SafraCoin.Core.Models;
using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Interfaces.Repositories;

public interface IInvestorRepository
{
    Task AddInvestor(Investor investor);
    Task<IEnumerable<User>> GetInvestors();
}

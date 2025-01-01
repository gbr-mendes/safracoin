using SafraCoin.Core.Models;
using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Interfaces.Repositories.EFRepository;

public interface IInvestorRepository
{
    Task<bool> AddInvestor(Investor investor);
    Task<IEnumerable<InvestorVO>> GetInvestors();
}

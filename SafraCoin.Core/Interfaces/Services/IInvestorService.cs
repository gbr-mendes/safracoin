using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Interfaces.Services;

public interface IInvestorService
{
    Task<InvestorVO> Register(InvestorVO investor);
    Task<IEnumerable<InvestorVO>> GetInvestors();
}

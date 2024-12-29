using SafraCoin.Core.ValueObjects;
using SafraCoin.Core.DTO.Investors;

namespace SafraCoin.Core.Interfaces.Services;

public interface IInvestorService
{
    Task<OutboundRegisterInvestor> Register(InvestorVO investor);
    Task<IEnumerable<OutboundGetInvestor>> GetInvestors();
}

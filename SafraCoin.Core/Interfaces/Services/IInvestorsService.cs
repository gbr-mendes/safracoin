using SafraCoin.Core.ValueObjects;
using Optional;
using SafraCoin.Infra.DTO.Investors;
using SafraCoin.Core.DTO.Investors;

namespace SafraCoin.Core.Interfaces.Services;

public interface IInvestorsService
{
    Task<OutboundRegisterInvestor> Register(InvestorVO investor);
    Task<IEnumerable<OutboundGetInvestor>> GetInvestors();
}

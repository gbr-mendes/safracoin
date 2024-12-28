using AutoMapper;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Core.Models;
using SafraCoin.Core.DTO.Investors;
using SafraCoin.Infra.DTO.Investors;

namespace SafraCoin.Infra.AutoMapping;

public class SafraCoinProfile : Profile
{
    public SafraCoinProfile()
    {
        CreateMap<InvestorVO, Investor>();
        CreateMap<Investor, InvestorVO>();
        CreateMap<InboundRegisterInvestor, InvestorVO>();
        CreateMap<OutboundRegisterInvestor, InvestorVO>();
        CreateMap<OutboundGetInvestor, InvestorVO>();
        CreateMap<OutboundGetInvestor, User>();
        CreateMap<User, OutboundGetInvestor>();
        CreateMap<User, OutboundRegisterInvestor>();
        CreateMap<OutboundRegisterInvestor, User>();
    }
}

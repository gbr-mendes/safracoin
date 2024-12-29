using AutoMapper;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Core.Models;
using SafraCoin.Core.DTO.Investors;
using SafraCoin.Core.DTO.Farmers;

namespace SafraCoin.Infra.AutoMapping;

public class SafraCoinProfile : Profile
{
    public SafraCoinProfile()
    {
        CreateMap<InvestorVO, Investor>().DisableCtorValidation();
        CreateMap<Investor, InvestorVO>().DisableCtorValidation();
        CreateMap<InboundRegisterInvestor, InvestorVO>().DisableCtorValidation();
        CreateMap<OutboundRegisterInvestor, InvestorVO>().DisableCtorValidation();
        CreateMap<OutboundGetInvestor, InvestorVO>().DisableCtorValidation();
        CreateMap<OutboundGetInvestor, User>().DisableCtorValidation();
        CreateMap<User, OutboundGetInvestor>().DisableCtorValidation();
        CreateMap<User, OutboundRegisterInvestor>().DisableCtorValidation();
        CreateMap<OutboundRegisterInvestor, User>().DisableCtorValidation();
        CreateMap<OutboundRegisterFarmer, User>().DisableCtorValidation();
        CreateMap<User, OutboundRegisterFarmer>().DisableCtorValidation();
        CreateMap<InboundRegisterFarmer, FarmerVO>().DisableCtorValidation();
        CreateMap<Farmer, OutboundGetFarmer>().DisableCtorValidation();
        CreateMap<FarmerVO, OutboundGetFarmer>().DisableCtorValidation();
        CreateMap<FarmerVO, OutboundRegisterFarmer>().DisableCtorValidation();
    }
}

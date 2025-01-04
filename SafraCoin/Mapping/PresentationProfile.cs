using AutoMapper;
using SafraCoin.Core.ValueObjects;
using SafraCoin.DTO.Farmers;
using SafraCoin.DTO.Investors;

namespace SafraCoin.Mapping;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        CreateMap<InvestorVO, OutboundGetInvestor>().DisableCtorValidation();
        CreateMap<InvestorVO, OutboundRegisterInvestor>().DisableCtorValidation();
        CreateMap<FarmerVO, OutboundGetFarmer>().DisableCtorValidation();
        CreateMap<FarmerVO, OutboundRegisterFarmer>().DisableCtorValidation();
    }
}

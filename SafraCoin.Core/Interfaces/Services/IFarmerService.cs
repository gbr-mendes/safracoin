using SafraCoin.Core.DTO.Farmers;
using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Interfaces.Services;

public interface IFarmerService
{
    Task<OutboundRegisterFarmer> Register(FarmerVO inboundRegisterFarmer);
    Task<IEnumerable<OutboundGetFarmer>> GetFarmers();
}

using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Interfaces.Services;

public interface IFarmerService
{
    Task<FarmerVO> Register(FarmerVO inboundRegisterFarmer);
    Task<IEnumerable<FarmerVO>> GetFarmers();
}

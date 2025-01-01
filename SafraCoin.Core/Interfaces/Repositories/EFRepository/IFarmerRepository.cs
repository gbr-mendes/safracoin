using FarmerModel = SafraCoin.Core.Models.Farmer;
using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Interfaces.Repositories.EFRepository;

public interface IFarmerRepository
{
    Task<bool> AddFarmer(FarmerModel farmer);
    Task<IEnumerable<FarmerVO>> GetFarmers();
}

using SafraCoin.Core.Models;
using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Interfaces.Repositories.EFRepository;

public interface IFarmerRepository
{
    Task<bool> AddFarmer(Farmer farmer);
    Task<IEnumerable<FarmerVO>> GetFarmers();
}

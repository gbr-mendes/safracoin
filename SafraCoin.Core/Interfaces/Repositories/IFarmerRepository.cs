using SafraCoin.Core.Models;

namespace SafraCoin.Core.Interfaces.Repositories;

public interface IFarmerRepository
{
    Task<bool> AddFarmer(Farmer farmer);
    Task<IEnumerable<Farmer>> GetFarmers();
}

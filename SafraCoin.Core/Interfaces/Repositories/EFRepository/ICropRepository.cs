using SafraCoin.Core.Models;

namespace SafraCoin.Core.Interfaces.Repositories.EFRepository;

public interface ICropRepository
{
    Task<bool> AddCrop(Crop crop);
}

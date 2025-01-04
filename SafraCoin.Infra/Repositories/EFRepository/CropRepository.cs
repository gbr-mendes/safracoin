using SafraCoin.Core.Interfaces.Repositories.EFRepository;
using SafraCoin.Core.Models;
using SafraCoin.Infra.Db;

namespace SafraCoin.Infra.Repositories.EFRepository;

public class CropRepository : ICropRepository
{
    private readonly AppDbContext _context;

    public CropRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddCrop(Crop crop)
    {
        await _context.Crops.AddAsync(crop);
        return await _context.SaveChangesAsync() != 0;
    }
}

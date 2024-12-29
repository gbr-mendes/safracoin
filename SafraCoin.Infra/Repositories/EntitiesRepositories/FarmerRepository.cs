using Microsoft.EntityFrameworkCore;
using SafraCoin.Core.Interfaces.Repositories;
using SafraCoin.Core.Models;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Infra.Db;

namespace SafraCoin.Infra.Repositories.EntitiesRepositories;

public class FarmerRepository : IFarmerRepository
{
    private readonly AppDbContext _context;

    public FarmerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FarmerVO>> GetFarmers()
    {
        var farmers = from farmer in _context.Farmers
            join user in _context.Users on farmer.User.Id equals user.Id
            select new FarmerVO
            (
                farmer.Id,
                user.Id,
                user.Name,
                user.Email,
                string.Empty,
                farmer.Cnpj,
                farmer.PhoneNumber
            );
        return await farmers.ToListAsync();
    }

    public async Task<bool> AddFarmer(Farmer farmer)
    {
        await _context.Farmers.AddAsync(farmer);
        return await _context.SaveChangesAsync() != 0;
    }
}

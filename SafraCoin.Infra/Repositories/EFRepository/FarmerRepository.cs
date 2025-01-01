using Microsoft.EntityFrameworkCore;
using SafraCoin.Core.Interfaces.Repositories.EFRepository;
using SafraCoin.Core.Models;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Infra.Db;
using FarmerModel = SafraCoin.Core.Models.Farmer;

namespace SafraCoin.Infra.Repositories.EFRepository;

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
                farmer.PhoneNumber,
                farmer.AccountAddress,
                user.Role
            );
        return await farmers.ToListAsync();
    }

    public async Task<bool> AddFarmer(FarmerModel farmer)
    {
        await _context.Farmers.AddAsync(farmer);
        return await _context.SaveChangesAsync() != 0;
    }
}

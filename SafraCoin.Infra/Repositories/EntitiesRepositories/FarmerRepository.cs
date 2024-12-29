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

    public async Task<IEnumerable<Farmer>> GetFarmers()
    {
        // montar objeto contendo todos os atributos do usuario e farmer
        return await _context.Farmers.ToListAsync();
    }

    public async Task<bool> AddFarmer(Farmer farmer)
    {
        await _context.Farmers.AddAsync(farmer);
        return await _context.SaveChangesAsync() != 0;
    }
}

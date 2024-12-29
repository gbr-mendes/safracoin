using Microsoft.EntityFrameworkCore;
using SafraCoin.Core.Interfaces.Repositories;
using SafraCoin.Core.Models;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Infra.Db;

namespace SafraCoin.Infra.Repositories.EntitiesRepositories;

public class InvestorRepository : IInvestorRepository
{
    private readonly AppDbContext _context;

    public InvestorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetInvestors()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> AddInvestor(Investor investor)
    {
        await _context.Investors.AddAsync(investor);
        return await _context.SaveChangesAsync() != 0;
    }
}

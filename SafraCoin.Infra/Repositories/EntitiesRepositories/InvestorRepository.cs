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

    public async Task<IEnumerable<InvestorVO>> GetInvestors()
    {
        var investors = from investor in _context.Investors
            join user in _context.Users on investor.User.Id equals user.Id
            select new InvestorVO(
                investor.Id,
                user.Id,
                user.Name,
                user.Email,
                string.Empty,
                user.Role
            );
        return await investors.ToListAsync();
    }

    public async Task<bool> AddInvestor(Investor investor)
    {
        await _context.Investors.AddAsync(investor);
        return await _context.SaveChangesAsync() != 0;
    }
}

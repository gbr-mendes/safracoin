using Microsoft.EntityFrameworkCore;
using Optional;
using SafraCoin.Core.Interfaces.Repositories;
using SafraCoin.Core.Models;
using SafraCoin.Infra.Db;

namespace SafraCoin.Infra.Repositories.EntitiesRepositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<bool> UserExists(string email)
    {
        return _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        return await _context.SaveChangesAsync() != 0;
    }

    public async Task<Option<User>> GetUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user != null ? Option.Some(user) : Option.None<User>();
    }
}

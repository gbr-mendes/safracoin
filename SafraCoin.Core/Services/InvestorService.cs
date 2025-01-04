using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Core.Models;
using SafraCoin.Core.Interfaces.Repositories.EFRepository;
using SafraCoin.Core.Exceptions;

namespace SafraCoin.Core.Services;

public class InvestorService : IInvestorService
{
    private readonly IAuthService _authService;
    private readonly IInvestorRepository _investorRepository;
    private readonly IUserRepository _userRepository;

    public InvestorService(
        IAuthService authService,
        IInvestorRepository investorRepository,
        IUserRepository userRepository)
    {
        _authService = authService;
        _investorRepository = investorRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<InvestorVO>> GetInvestors()
    {
        var investors = await _investorRepository.GetInvestors();
        return investors;
    }

    public async Task<InvestorVO> Register(InvestorVO investorVO)
    {
        if (await _userRepository.UserExists(investorVO.Email))
        {
            throw new DomainException($"User with email {investorVO.Email} already exists");
        }

        var user = new User
        {
            Name = investorVO.Name,
            Email = investorVO.Email,
            PasswordHash = _authService.HashPassword(investorVO.Password),
            Role = investorVO.Role
        };

        if (!await _userRepository.AddUser(user))
        {
            throw new DomainException("An error has occurred while registering the user");
        }

        var investor = new Investor
        {
            User = user
        };

        if (!await _investorRepository.AddInvestor(investor))
        {
            throw new DomainException("An error has occurred while registering the investor");
        }

        var result = new InvestorVO(
            investor.Id,
            user.Id,
            user.Name,
            user.Email,
            string.Empty,
            investorVO.Role);

        return result;
    }
}

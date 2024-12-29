using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Core.Models;
using Microsoft.AspNetCore.Identity;
using SafraCoin.Core.Interfaces.Repositories;
using AutoMapper;
using SafraCoin.Infra.DTO.Investors;
using SafraCoin.Core.DTO.Investors;
using SafraCoin.Core.Exceptions;

namespace SafraCoin.Core.Services;

public class InvestorsService : IInvestorsService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IInvestorRepository _investorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public InvestorsService(
        IPasswordHasher<User> passwordHasher,
        IInvestorRepository investorRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _passwordHasher = passwordHasher;
        _investorRepository = investorRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OutboundGetInvestor>> GetInvestors()
    {
        var investors = await _investorRepository.GetInvestors();
        return _mapper.Map<IEnumerable<OutboundGetInvestor>>(investors);
    }

    public async Task<OutboundRegisterInvestor> Register(InvestorVO investorVO)
    {
        if (await _userRepository.UserExists(investorVO.Email))
        {
            throw new DomainException($"User with email {investorVO.Email} already exists");
        }

        var user = new User
        {
            Name = investorVO.Name,
            Email = investorVO.Email,
            PasswordHash = _passwordHasher.HashPassword(null, investorVO.Password)
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

        return _mapper.Map<OutboundRegisterInvestor>(user);
    }
}

using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Core.Models;
using Microsoft.AspNetCore.Identity;
using SafraCoin.Core.Interfaces.Repositories;
using AutoMapper;
using SafraCoin.Infra.DTO.Investors;
using SafraCoin.Core.DTO.Investors;

namespace SafraCoin.Core.Services;

public class InvestorsService : IInvestorsService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IInvestorRepository _investorRepository;
    private readonly IMapper _mapper;

    public InvestorsService(
        IPasswordHasher<User> passwordHasher,
        IInvestorRepository investorRepository,
        IMapper mapper)
    {
        _passwordHasher = passwordHasher;
        _investorRepository = investorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OutboundGetInvestor>> GetInvestors()
    {
        var investors = await _investorRepository.GetInvestors();
        return _mapper.Map<IEnumerable<OutboundGetInvestor>>(investors);
    }

    public async Task<OutboundRegisterInvestor> Register(InvestorVO investorVO)
    {
        var user = new User
        {
            Name = investorVO.Name,
            Email = investorVO.Email,
        };
        user.PasswordHash =  _passwordHasher.HashPassword(user, investorVO.Password);
        var investor = new Investor
        {
            User = user
        };

        await _investorRepository.AddInvestor(investor);
        return _mapper.Map<OutboundRegisterInvestor>(user);
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SafraCoin.Core.DTO.Farmers;
using SafraCoin.Core.Exceptions;
using SafraCoin.Core.Interfaces.Repositories;
using SafraCoin.Core.Interfaces.Repositories.EFRepository;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.Models;
using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Services;

public class FarmerService : IFarmerService
{
    private readonly IUserRepository _userRepository;
    private readonly IFarmerRepository _farmerRepository;
    private readonly IRedisRepository _redisRepository;
    private readonly IProtoService _protoService;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMapper _mapper;
    private static readonly string streamKey = "FarmerAccounts";
    
    public FarmerService(
        IUserRepository userRepository,
        IFarmerRepository farmerRepository,
        IRedisRepository redisRepository,
        IProtoService protoService,
        IPasswordHasher<User> passwordHasher,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _farmerRepository = farmerRepository;
        _redisRepository = redisRepository;
        _protoService = protoService;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OutboundGetFarmer>> GetFarmers()
    {
        var farmers = await _farmerRepository.GetFarmers();
        return _mapper.Map<IEnumerable<OutboundGetFarmer>>(farmers);
    }

    public async Task<OutboundRegisterFarmer> Register(FarmerVO farmerVO)
    {
        if (await _userRepository.UserExists(farmerVO.Email))
        {
            throw new DomainException($"User with email {farmerVO.Email} already exists");
        }

        var user = new User
        {
            Id = farmerVO.UserId,
            Name = farmerVO.Name,
            Email = farmerVO.Email,
            PasswordHash = _passwordHasher.HashPassword(null, farmerVO.Password),
            Role = farmerVO.Role
        };

        if (!await _userRepository.AddUser(user))
        {
            throw new DomainException("An error has occurred while registering the user");
        }

        var farmer = new Farmer
        {
            Id = farmerVO.Id,
            User = user,
            Cnpj = farmerVO.Cnpj,
            PhoneNumber = farmerVO.PhoneNumber,
            AccountAddress = farmerVO.AccountAddress
        };

        if (!await _farmerRepository.AddFarmer(farmer))
        {
            throw new DomainException("An error has occurred while registering the farmer");
        }

        var result = new FarmerVO(
            farmerVO.Id,
            farmerVO.UserId,
            farmerVO.Name,
            farmerVO.Email,
            farmerVO.Password,
            farmerVO.Cnpj,
            farmerVO.PhoneNumber,
            farmerVO.AccountAddress,
            farmerVO.Role);

        var redisEntry = new FarmerAccount
        {
            Email = farmerVO.Email,
            Address = farmerVO.AccountAddress
        };

        var serializedEntry = _protoService.Serialize(redisEntry);
        await _redisRepository.AddEntryToStreamAsync(streamKey, serializedEntry);

        return _mapper.Map<OutboundRegisterFarmer>(result);
    }
}

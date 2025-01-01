using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SafraCoin.Core.DTO.Farmers;
using SafraCoin.Core.Enums;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Controllers;

[ApiController]
[Route("[controller]")]
public class FarmerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IFarmerService _farmersService;
    public FarmerController(IMapper mapper, IFarmerService farmersService)
    {
        _mapper = mapper;
        _farmersService = farmersService;
    }

    [HttpGet(Name = "GetFarmers")]
    public async Task<ActionResult<IEnumerable<OutboundGetFarmer>>> Get()
    {
        var farmers = await _farmersService.GetFarmers();
        return Ok(_mapper.Map<List<OutboundGetFarmer>>(farmers));
    }

    [HttpPost(Name = "RegisterFarmer")]
    public async Task<ActionResult<OutboundRegisterFarmer>> Register(InboundRegisterFarmer inboundFarmer)
    {
        try
        {
            var farmer = new FarmerVO(
                Guid.NewGuid(),
                Guid.NewGuid(),
                inboundFarmer.Name,
                inboundFarmer.Email,
                inboundFarmer.Password,
                inboundFarmer.Cnpj,
                inboundFarmer.PhoneNumber,
                inboundFarmer.AccountAddress,
                Role.Farmer);

            var result = await _farmersService.Register(farmer);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

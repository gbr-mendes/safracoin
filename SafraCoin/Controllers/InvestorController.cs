using Microsoft.AspNetCore.Mvc;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.Models;
using SafraCoin.Core.DTO.Investors;
using AutoMapper;
using SafraCoin.Core.ValueObjects;
using SafraCoin.Core.Enums;

namespace SafraCoin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvestorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IInvestorService _investorsService;

    public InvestorController(IMapper mapper, IInvestorService investorsService)
    {
        _mapper = mapper;
        _investorsService = investorsService;
    }

    [HttpGet(Name = "GetInvestors")]
    public async Task<ActionResult<IEnumerable<OutboundGetInvestor>>> Get()
    {
        var investors = await _investorsService.GetInvestors();
        return Ok(_mapper.Map<List<OutboundGetInvestor>>(investors));
    }

    [HttpPost(Name = "RegisterInvestor")]
    public async Task<ActionResult<OutboundRegisterInvestor>> Register(InboundRegisterInvestor inboundInvestor)
    {
        try
        {
            var investor = new InvestorVO(
                Guid.NewGuid(),
                Guid.NewGuid(),
                inboundInvestor.Name,
                inboundInvestor.Email,
                inboundInvestor.Password,
                Role.Investor
            );

            var result = await _investorsService.Register(investor);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

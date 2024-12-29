using Microsoft.AspNetCore.Mvc;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.Models;
using SafraCoin.Core.DTO.Investors;
using AutoMapper;
using SafraCoin.Core.ValueObjects;

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
            var investor = _mapper.Map<InvestorVO>(inboundInvestor);
            var result = await _investorsService.Register(investor);
            return Ok(_mapper.Map<OutboundRegisterInvestor>(result));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

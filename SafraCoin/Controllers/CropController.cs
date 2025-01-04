using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafraCoin.Core.Enums;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.ValueObjects;
using SafraCoin.DTO.Crops;

namespace SafraCoin.Controllers;

[ApiController]
[Route("[controller]")]
public class CropController : ControllerBase
{
    private readonly ILogger<CropController> _logger;
    private readonly ICropService _cropService;
    
    public CropController(ILogger<CropController> logger, ICropService cropService)
    {
        _logger = logger;
        _cropService = cropService;
    }

    [HttpPost]
    [Authorize(Roles = nameof(Role.Farmer))]
    public async Task<ActionResult> Tokenize(InboundTokenize inbound)
    {
        try
        {
            var userId = Guid.Parse(
            User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        
            var cropTokenizeVO = new CropTokenizeVO(
                userId,
                inbound.Name,
                inbound.ExpectedYield,
                inbound.ExpectedRevenue,
                inbound.OperetionalCost,
                inbound.HarvestDate,
                inbound.DistributionPercentage,
                inbound.TokenQuantity
            );

            await _cropService.Tokenize(cropTokenizeVO);

            return Ok(new {message = "Crop tokenized successfully"});
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

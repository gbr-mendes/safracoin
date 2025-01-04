using Microsoft.AspNetCore.Mvc;

namespace SafraCoin.Controllers;

[ApiController]
[Route("[controller]")]
public class SafraCoinController : ControllerBase
{
    public SafraCoinController()
    {
    }

    [HttpGet]
    public async Task<ActionResult> Tokenize()
    {
        return Ok();
    }
}

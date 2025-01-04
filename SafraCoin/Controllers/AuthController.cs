using Microsoft.AspNetCore.Mvc;
using Optional.Unsafe;
using SafraCoin.DTO.Authentication;
using SafraCoin.Core.Interfaces.Repositories.EFRepository;
using SafraCoin.Core.Interfaces.Services;

namespace SafraCoin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    public AuthController(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    [Route("login")]
    [HttpPost]
    public async Task<ActionResult<OutboundLogin>> Login(InboundLogin inboundLogin)
    {
        var userOption = await _userRepository.GetUserByEmail(inboundLogin.Email);
        if (!userOption.HasValue)
        {
            return NotFound($"User with email {inboundLogin.Email} not found");
        }

        var user = userOption.ValueOrFailure();

        if (!_authService.IsPasswordValid(user.PasswordHash, inboundLogin.Password))
        {
            return Unauthorized("Invalid password");
        }

        return Ok(new OutboundLogin
        {
            Token = _authService.GenerateToken(user),
            Expiration = DateTime.UtcNow.AddHours(1)
        });
    }
}

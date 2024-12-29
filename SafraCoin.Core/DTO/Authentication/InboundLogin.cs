using System.ComponentModel.DataAnnotations;

namespace SafraCoin.Core.DTO.Authentication;

public class InboundLogin
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}

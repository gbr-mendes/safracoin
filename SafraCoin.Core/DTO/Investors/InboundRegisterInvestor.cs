using System.ComponentModel.DataAnnotations;

namespace SafraCoin.Core.DTO.Investors;

public class InboundRegisterInvestor
{
    [Required]
    public required string Name { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "The provided email is not valid")]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}

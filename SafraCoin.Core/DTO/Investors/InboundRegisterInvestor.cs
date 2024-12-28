using System.ComponentModel.DataAnnotations;

namespace SafraCoin.Core.DTO.Investors;

public class InboundRegisterInvestor
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}

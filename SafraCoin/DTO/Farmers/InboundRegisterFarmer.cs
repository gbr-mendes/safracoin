using System.ComponentModel.DataAnnotations;

namespace SafraCoin.DTO.Farmers;

public class InboundRegisterFarmer
{
    [Required]
    public required string Name { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required string Cnpj { get; set; }
    [Required]
    public required string PhoneNumber { get; set; }
    [Required]
    public required string AccountAddress { get; set; }
}

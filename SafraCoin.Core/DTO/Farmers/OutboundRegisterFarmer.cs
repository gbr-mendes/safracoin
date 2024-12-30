using SafraCoin.Core.Enums;

namespace SafraCoin.Core.DTO.Farmers;

public class OutboundRegisterFarmer
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Cnpj { get; set; }
    public required string PhoneNumber { get; set; }
    public required Role Role { get; set; }
}

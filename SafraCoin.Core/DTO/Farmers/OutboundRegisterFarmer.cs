namespace SafraCoin.Core.DTO.Farmers;

public class OutboundRegisterFarmer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}

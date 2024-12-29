namespace SafraCoin.Core.DTO.Farmers;

public class OutboundGetFarmer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Cnpj { get; set; }
    public required string PhoneNumber { get; set; }
}

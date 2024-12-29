namespace SafraCoin.Core.Models;

public class Farmer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required User User { get; set; }
    public required string Cnpj { get; set; }
    public required string PhoneNumber { get; set; }
}

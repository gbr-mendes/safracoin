namespace SafraCoin.Core.Models;

public class Investor
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required User User { get; set; }
}

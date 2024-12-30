namespace SafraCoin.Core.DTO.Investors;

public class OutboundGetInvestor
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}

using SafraCoin.Core.Enums;

namespace SafraCoin.DTO.Investors;

public class OutboundGetInvestor
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required Role Role { get; set; }
}

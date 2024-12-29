namespace SafraCoin.Core.ValueObjects;
public record InvestorVO
{
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }
}

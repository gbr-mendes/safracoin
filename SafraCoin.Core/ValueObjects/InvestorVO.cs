namespace SafraCoin.Core.ValueObjects;
public record InvestorVO
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }

    public InvestorVO(Guid id, Guid userId, string name, string email, string password)
    {
        Id = id;
        UserId = userId;
        Name = name;
        Email = email;
        Password = password;
    }
}

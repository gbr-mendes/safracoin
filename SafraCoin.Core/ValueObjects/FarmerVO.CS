using SafraCoin.Core.Enums;

namespace SafraCoin.Core.ValueObjects;

public class FarmerVO
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }
    public string? Cnpj { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? AccountAddress { get; private set; }
    public Role Role { get; private set; }

    public FarmerVO(Guid id, Guid userId, string name, string email, string password, string cnpj, string phoneNumber,string accountAddress, Role role)
    {
        Id = id;
        UserId = userId;
        Name = name;
        Email = email;
        Password = password;
        Cnpj = cnpj;
        PhoneNumber = phoneNumber;
        AccountAddress = accountAddress;
        Role = role;
    }
}

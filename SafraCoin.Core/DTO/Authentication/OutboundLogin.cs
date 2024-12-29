namespace SafraCoin.Core.DTO.Authentication;

public class OutboundLogin
{
    public required string Token { get; set; }
    public DateTime Expiration { get; set; }
}

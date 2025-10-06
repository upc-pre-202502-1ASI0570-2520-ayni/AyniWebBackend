namespace AyniWebBackend.Security.Domain.Services.Communication;

public class AuthenticationResponse
{
    public int Id  { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}
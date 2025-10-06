using System.ComponentModel.DataAnnotations;

namespace AyniWebBackend.Security.Domain.Services.Communication;

public class AuthenticationRequest
{
    [Required] public string Username { get; set; }
    
    [Required] public string Email { get; set; }
    
    public string Role { get; set; }

    [Required] public string Password { get; set; }
}
using AyniWebBackend.Security.Domain.Models;

namespace AyniWebBackend.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}
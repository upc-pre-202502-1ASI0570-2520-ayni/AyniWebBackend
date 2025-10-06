using AyniWebBackend.Security.Domain.Models;
using AyniWebBackend.Security.Domain.Services.Communication;

namespace AyniWebBackend.Security.Domain.Services;

public interface IUserService
{
    Task<AuthenticationResponse> Authenticate(AuthenticationRequest model);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, UpdateRequest model);
    Task DeleteAsync(int id);
}
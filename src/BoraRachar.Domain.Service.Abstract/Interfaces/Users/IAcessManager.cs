using BoraRachar.Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public interface IAcessManager
{
    Task<User> GetUserByUsername(string username);
    Task<SignInResult> ValidateCredentials(User user, string password);
}

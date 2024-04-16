using System.Security.Claims;
using BoraRachar.Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public interface IUserManager
{
    Task<IdentityResult> CreateUser(User user, string password);
    Task<IdentityResult> ChangePassword(User user, string password);
    Task<IdentityResult> AddToRoles(User user, IEnumerable<string> roles);
    Task<User> GetById(Guid idUser);
    Task<User> GetByEmail(string email);
    Task<IdentityResult> Update(User user);
    Task<IdentityResult> RemoveRoles(User user, IEnumerable<string> roles);
    Task<IList<string>> GetRoles(User user);
    Task<IEnumerable<User>> GetAll();
    Task<IList<Claim>> GetClaims(User user);
    Task<IdentityResult> ReplaceClaim(User user, Claim claimLastRt, Claim newLastRtClaim);
    Task<IdentityResult> AddClaim(User user, Claim newLastRtClaim);
}

using System.Security.Claims;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public interface IUserInfoService
{
    string Name { get; }
    string Nome { get; }
    bool IsAuthenticated();
    IEnumerable<Claim> GetClaimsIdentity();
}

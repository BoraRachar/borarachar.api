using System.Security.Claims;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using Microsoft.AspNetCore.Http;

namespace BoraRachar.Domain.Service.Concretes.Users;

public class UserInfoService : IUserInfoService
{
    private readonly IHttpContextAccessor _accessor;

    public UserInfoService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string Name => _accessor.HttpContext.User.Identity.Name;

    public string Nome => _accessor.HttpContext.User.Identity.Name;

    public IEnumerable<Claim> GetClaimsIdentity()
    {
        return _accessor.HttpContext.User.Claims;
    }

    public bool IsAuthenticated()
    {
        return _accessor.HttpContext.User.Identity.IsAuthenticated;
    }
}

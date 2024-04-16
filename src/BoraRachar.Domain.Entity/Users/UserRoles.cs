using Microsoft.AspNetCore.Identity;

namespace BoraRachar.Domain.Entity.Users;

public class UserRoles : IdentityUserRole<string>
{
    public virtual User User { get; set; }
    public virtual Roles Roles { get; set; }
}


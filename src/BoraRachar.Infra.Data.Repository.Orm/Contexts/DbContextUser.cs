using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BoraRachar.Domain.Entity.Users;

namespace BoraRachar.Infra.Data.Repository.Orm.Contexts;

public class DbContextUser : IdentityDbContext<User, Roles, string, IdentityUserClaim<string>,
UserRoles, IdentityUserLogin<string>,
IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public DbContextUser(DbContextOptions<DbContextUser> options)
       : base(options)
    {
    }

    public DbSet<Roles> Roles { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserRoles>(userRole =>
        {
            userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            userRole.HasOne(ur => ur.Roles)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });
    }
}

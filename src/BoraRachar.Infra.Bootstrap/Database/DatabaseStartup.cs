using System.Diagnostics.CodeAnalysis;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Repository.Orm.Abstract.Contexts;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Infra.Data.Repository.Orm.Contexts;
using BoraRachar.Infra.Data.Repository.Orm.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using DbContext = BoraRachar.Infra.Data.Repository.Orm.Contexts.DbContext;

namespace BoraRachar.Infra.Bootstrap.Database;

[ExcludeFromCodeCoverage]
public static class tartup
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IDbContext, DbContext>(
            opt =>
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .UseSqlServer(configuration["ConnectionStrings:Connection"])
        );

        services.AddDbContext<DbContextUser>(
            opt =>
                opt.UseSqlServer(configuration["ConnectionStrings:Connection"])
        );

        services.AddIdentity<User, Roles>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 50;

                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<DbContextUser>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://borarachar.online",
                ValidAudience = "BoraRachar.API"
            };
        });

        services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", Policy =>
            {
                Policy.RequireAuthenticatedUser();
                Policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
            });
        });
        services.AddAuthorization();
        services.AddMemoryCache();
        services.AddJwksManager().PersistKeysInMemory().UseJwtValidation();

        services.AddEndpointsApiExplorer();

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        return services;
    }
}
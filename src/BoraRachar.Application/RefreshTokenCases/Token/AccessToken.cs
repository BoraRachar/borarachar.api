using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BoraRachar.Domain.Entity.Users;

namespace BoraRachar.Application.RefreshTokenCases.Token
{
    internal class AccessToken
    {
        internal async Task<string> GenerateAccessToken(UserManager<User> userManager, IJwtService jwtService, string? email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var userRoles = await userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));
            claims.AddRange(await userManager.GetClaimsAsync(user));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("94ec8dc3fc663b2d178f32ea4d7d8f9bfa8385c5"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(issuer: "https://borarachar.online", audience: "BoraRachar.API",claims: claims, expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);
          
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}

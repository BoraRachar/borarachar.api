using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BoraRachar.Domain.Entity.Users;

namespace BoraRachar.Application.RefreshTokenCases.Token
{
    internal class AccessToken
    {
        internal async Task<string> GenerateAccessToken(UserManager<User> userManager, IJwtService jwtService, string? email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var userRoles = await userManager.GetRolesAsync(user);
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(await userManager.GetClaimsAsync(user));
            identityClaims.AddClaims(userRoles.Select(s => new Claim("role", s)));

            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "https://borarachar.online",
                Audience = "BoraRachar.RefreshToken.API",
                SigningCredentials = await jwtService.GetCurrentSigningCredentials(),
                Subject = identityClaims,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(60),
                IssuedAt = DateTime.UtcNow,
                TokenType = "at+jwt"
            });

            var encodedJwt = handler.WriteToken(securityToken);
            return encodedJwt;
        }
    }
}

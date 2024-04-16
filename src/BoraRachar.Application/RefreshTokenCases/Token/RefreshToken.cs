using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BoraRachar.Domain.Entity.Users;

namespace BoraRachar.Application.RefreshTokenCases.Token
{
    internal class RefreshToken
    {
        internal async Task<string> GenerateRefreshToken(UserManager<User> userManager, IJwtService jwtService, string? email)
        {
            var jti = Guid.NewGuid().ToString();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            };

            // Necessário converver para IdentityClaims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "https://Dev2Y.com.br",
                Audience = "Dev2Y.RefreshToken.API",
                SigningCredentials = await jwtService.GetCurrentSigningCredentials(),
                Subject = identityClaims,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddDays(30),
                TokenType = "rt+jwt"
            });
            await UpdateLastGeneratedClaim(userManager, email, jti);
            var encodedJwt = handler.WriteToken(securityToken);
            return encodedJwt;
        }

        static async Task UpdateLastGeneratedClaim(UserManager<User> userManager, string? email, string jti)
        {
            var user = await userManager.FindByEmailAsync(email);
            var claims = await userManager.GetClaimsAsync(user);
            var newLastRtClaim = new Claim("LastRefreshToken", jti);

            var claimLastRt = claims.FirstOrDefault(f => f.Type == "LastRefreshToken");
            if (claimLastRt != null)
                await userManager.ReplaceClaimAsync(user, claimLastRt, newLastRtClaim);
            else
                await userManager.AddClaimAsync(user, newLastRtClaim);

        }
    }
}

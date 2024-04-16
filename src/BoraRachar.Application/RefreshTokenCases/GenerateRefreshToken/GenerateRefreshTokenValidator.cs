using FluentValidation;
using BoraRachar.Application.Bases;

namespace BoraRachar.Application.RefreshTokenCases.GenerateRefreshToken
{
    public class GenerateRefreshTokenValidator : RequestValidator<GenerateRefreshTokenRequest>
    {
        public GenerateRefreshTokenValidator()
        {
            RuleFor(r => r.RefreshToken)
                .NotEmpty()
                .WithMessage("Por favor, informe o refresh token");
        }
    }
}

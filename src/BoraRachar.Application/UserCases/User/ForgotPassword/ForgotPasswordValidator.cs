using FluentValidation;
using BoraRachar.Application.Bases;

namespace BoraRachar.Application.UserCases.User.ForgotPassword;

public class ForgotPasswordValidator : RequestValidator<ForgotPasswordRequest>
{
    public ForgotPasswordValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Por favor, informe o Email");
    }
}

using FluentValidation;
using BoraRachar.Application.Bases;

namespace BoraRachar.Application.LoginCases.Login;

public class LoginValidator : RequestValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Por favor, informe o e-mail");

        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Por favor, informe a senha");
    }
}

using BoraRachar.Application.Bases;
using FluentValidation;

namespace BoraRachar.Application.UserCases.User.CreateNewUser;

public class CreateNewUserValidator : RequestValidator<CreateNewUserRequest>
{
    public CreateNewUserValidator()
    {
        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage("Por favor, informe a senha")
            .MinimumLength(8)
            .WithMessage("Por favor, a senha deve ter no minimo 8 caracteres");

        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Por favor, informe seu e-mail");
    }
}
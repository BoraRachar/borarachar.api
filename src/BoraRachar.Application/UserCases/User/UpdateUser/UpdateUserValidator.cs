using FluentValidation;
using BoraRachar.Application.Bases;

namespace BoraRachar.Application.UserCases.User.UpdateUser;

public class UpdateUserValidator : RequestValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {

        RuleFor(r => r.Nome)
            .NotEmpty()
            .WithMessage("Por favor, informe o nome");

        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Por favor, informe seu e-mail");
    }
}

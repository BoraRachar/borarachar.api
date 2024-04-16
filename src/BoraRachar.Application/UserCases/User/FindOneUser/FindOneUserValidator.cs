using FluentValidation;
using BoraRachar.Application.Bases;

namespace BoraRachar.Application.UserCases.User.FindOneUser;

public class FindOneUserValidator : RequestValidator<FindOneUserRequest>
{
    public FindOneUserValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty()
            .WithMessage("Por favor, informe o Id");
    }
}
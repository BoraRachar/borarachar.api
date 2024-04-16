using FluentValidation;
using BoraRachar.Application.Bases;

namespace BoraRachar.Application.UserCases.User.ConfirmEmail;

public class ConfirmEmailValidation : RequestValidator<ConfirmEmailRequest>
{
	public ConfirmEmailValidation()
	{
		RuleFor(r => r.UserId)
			.NotEmpty()
			.WithMessage("Por favor, informe o codigo do usuario");

		RuleFor(r => r.Code)
			.NotEmpty()
			.WithMessage("Por favor, informe o codigo");
	}
}

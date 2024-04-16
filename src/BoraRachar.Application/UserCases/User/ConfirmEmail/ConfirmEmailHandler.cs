using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.ConfirmEmail;

public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailRequest, ResponseDto<None>>
{
	private readonly IUserService _userService;

	public ConfirmEmailHandler(IUserService userService)
	{
		_userService = userService;
	}

	public Task<ResponseDto<None>> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
	{
		return _userService.ConfimEmailAsync(request, cancellationToken);
	}
}

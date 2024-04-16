using System.Web;
using MediatR;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.ResetPassword;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResponseDto<None>>
{
	private readonly IUserService _userService;

	public ResetPasswordHandler(IUserService userService)
	{
		_userService = userService;
	}

	public Task<ResponseDto<None>> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
	{
		ResetPasswordRequest request0 = new ResetPasswordRequest();
		request0.IdU = string.IsNullOrEmpty(request.IdU) ? null : CriptografiaHelper.DecryptQueryString(HttpUtility.UrlDecode(request.IdU));
		request0.NovaSenha = request.NovaSenha;
		request0.ConfirmacaoSenha = request.ConfirmacaoSenha;
		request0.Token = request.Token;
		request0.Email = request.Email;

		return _userService.ResetPasswordAsync(request0, cancellationToken);
	}
}

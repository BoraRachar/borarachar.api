using System.Net;
using System.Text;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ConfirmEmail;
using BoraRachar.Infra.CrossCuting;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
	public async Task<ResponseDto<None>> ConfimEmailAsync(ConfirmEmailRequestDto request, CancellationToken cancellationToken)
	{
		logger.LogInformation("Metodo iniciado:{0}", nameof(ConfimEmailAsync));

		var user = await _userManager.FindByIdAsync(request.UserId);

		if (user == null)
			return ResponseDto<None>.Fail(HttpStatusCode.NotFound);

		var codeDecodedBytes = WebEncoders.Base64UrlDecode(request.Code);
		var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);
		var result = await _userManager.ConfirmEmailAsync(user, codeDecoded);
		if (result.Succeeded)
		{
			_emailService.EnvioEmailAsync(new EmailRequestDto(user.Email,
				"Confirmação de E-mail",
				$"<p> Ol&aacute;<b> {user.Nome}</b>,<br/><br/> Seu email foi confirmado com sucesso.<br/><br/>"));

			logger.LogInformation("Metodo finalizado:{0}", nameof(ConfimEmailAsync));
			return ResponseDto.Sucess("Email confirmado com sucesso", HttpStatusCode.NoContent);
		}
		else
		{
			logger.LogInformation("Metodo finalizado:{0}", nameof(ConfimEmailAsync));
			return ResponseDto.Fail("Erro ao confirmar email", HttpStatusCode.NoContent);
		}

	}
}

using System.Net;
using System.Text;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ResetPassword;
using BoraRachar.Infra.CrossCuting;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> ResetPasswordAsync(ResetPasswordRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ResetPasswordAsync));

        var user = string.IsNullOrEmpty(request.Email) ? await _userManager.FindByIdAsync(request.IdU) : await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);

        if (string.IsNullOrEmpty(request.Token))
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, code, request.NovaSenha);
        }
        else
        {
            var tokenDecodedBytes = WebEncoders.Base64UrlDecode(request.Token);
            var tokenDecoded = Encoding.UTF8.GetString(tokenDecodedBytes);
            var result = await _userManager.ResetPasswordAsync(user, tokenDecoded, request.NovaSenha);
        }

        _emailService.EnvioEmailAsync(new EmailRequestDto(user.Email,
              "Recuperação de Senha",
              $"<p> Ol&aacute;<b> {user.Nome}</b>,<br/><br/> Sua senha foi alterada com sucesso.<br/><br/>"));

        logger.LogInformation("Metodo finalizado:{0}", nameof(ResetPasswordAsync));
        return ResponseDto.Sucess("Alterado com sucesso", HttpStatusCode.NoContent);
    }
}

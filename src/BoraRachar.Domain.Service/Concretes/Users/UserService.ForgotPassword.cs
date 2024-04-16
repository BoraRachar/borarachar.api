
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ForgotPassword;
using BoraRachar.Infra.CrossCuting;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> ForgotPasswordAsync(ForgotPasswordRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ForgotPasswordAsync));

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
        var callbackUrl = $"{_config["UrlBase"]}/Email/ResetarSenha?token={token}&email={user.Email}";

        _emailService.EnvioEmailAsync(new EmailRequestDto(user.Email,
              "Recuperação de Senha",
              $"<p> Ol&aacute;<b> {user.Nome}</b>,<br/><br/> Recebemos a sua solicitação para resetar a sua senha.<br/><br/> <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Clique aqui</a> para resetar a sua senha. </p>"));

        logger.LogInformation("Metodo finalizado:{0}", nameof(ForgotPasswordAsync));
        return ResponseDto.Sucess("Alterado com sucesso", HttpStatusCode.NoContent);
    }
}

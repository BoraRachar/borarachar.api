using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ResetPassword;
using BoraRachar.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> ResetPasswordAsync(ResetPasswordRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ResetPasswordAsync));

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);

        var verifyCode = await _repositoryVerifyUser.Query.Where(c => c.UserId == user.Id).FirstOrDefaultAsync();


        if (verifyCode.Ativo.Equals(true))
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, request.NovaSenha);

            var reqSendEmail = new EmailRequestDto(user.Email,
               "Recuperação de Senha",
               $"<p> Ol&aacute;<b> {user.Nome}</b>,<br/><br/> Sua senha foi alterada com sucesso.<br/><br/>");

            _emailService.EnvioEmailAsync(reqSendEmail);

            verifyCode.Ativo = false;

            await _repositoryVerifyUser.UpdateAsync(verifyCode,
                cancellationToken,
                v => v.Ativo);

            await _repositoryVerifyUser.SaveChangeAsync(cancellationToken);

            return ResponseDto.Sucess("Alterado com sucesso", HttpStatusCode.NoContent);
        }
        else
        {
            return ResponseDto.Fail("Falha ao salvar a senha", HttpStatusCode.BadRequest);
        }

    }
}
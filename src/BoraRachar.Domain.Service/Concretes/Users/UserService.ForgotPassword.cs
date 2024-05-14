
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ForgotPassword;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> ForgotPasswordAsync(ForgotPasswordRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ForgotPasswordAsync));

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return ResponseDto<None>.Fail(HttpStatusCode.NotFound);

        var token = GenerateCode();


        var verify = new VerifyUser
        {
            Id = Guid.NewGuid().ToString().ToLower(),
            UserId = user.Id,
            Code = token,
            DataCadastro = DateTime.Now,
            Ativo = true
        };

        await _repositoryVerifyUser.InsertAsync(verify, cancellationToken);
        await _repositoryVerifyUser.SaveChangeAsync(cancellationToken);

        _emailService.EnvioEmailAsync(new EmailRequestDto(user.Email,
              "Recuperação de Senha",
              $"<p> Ol&aacute;<b> {user.Nome}</b>,<br/><br/> Recebemos a sua solicitação para resetar a sua senha.<br/><br/> Segue código de verificação : <strong>{token}</strong> </p> </p>"));

        logger.LogInformation("Metodo finalizado:{0}", nameof(ForgotPasswordAsync));
        return ResponseDto.Sucess("Alterado com sucesso", HttpStatusCode.NoContent);
    }
}

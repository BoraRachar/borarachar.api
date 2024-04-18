using System.Net;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.UpdateUser;
using BoraRachar.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> UpdateUserAsync(UpdateUserRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateUserAsync));
        try
        {
            var  user = await _userManager.Users.Where(u => u.Email == request.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                return ResponseDto.Fail($"Usuário não encontrado", HttpStatusCode.BadRequest);
            }

            user.Nome = request.Nome;
            user.Email = request.Email;
            user.PhoneNumber = request.Celular;
            user.DataAtualizacao = DateTime.Now;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return ResponseDto.Fail($"Falha ao atualizar usuário:{result.Errors.FirstOrDefault()}", HttpStatusCode.BadRequest);
            }
            return ResponseDto.Sucess("Atualizado com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateUserAsync));
        }
    }
}

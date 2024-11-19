using System.Net;
using System.Net.Mail;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindUniqueUserName;
using BoraRachar.Domain.Service.Concretes.Helpers;
using BoraRachar.Domain.Utils;
using BoraRachar.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<FindUniqueUserNameResponseDto>> FindUniqueUserNameAsync(FindUniqueUserNameRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindUniqueUserNameAsync));
        try
        {
            var  users = await _userManager.Users.Where(u => u.UserName == requestDto.Usuario).ToListAsync();

            if (users.Count <= 0)
            {
                return ResponseDto<FindUniqueUserNameResponseDto>.Sucess("Usuario Disponivel.", HttpStatusCode.NoContent);
            }
            
            MailAddress enderecoEmail = new MailAddress(users.FirstOrDefault().Email);
            
            string nomeUsuario = enderecoEmail.User;

            List<string> userNames = new List<string>();
            for (var i = 0; i < 3; i++)
            {
                var randon = ServiceHelpers.randonName();
                userNames.Add(string.Concat(nomeUsuario,"-", randon));
            }

            var result = new FindUniqueUserNameResponseDto
            {
                UserNames = userNames
            };
           
            return ResponseDto<FindUniqueUserNameResponseDto>.Sucess(result);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<FindUniqueUserNameResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindUniqueUserNameAsync));
        }
    }
}
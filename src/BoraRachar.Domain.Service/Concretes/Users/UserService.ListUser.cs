using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ListUsers;
using BoraRachar.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<IEnumerable<ListUsersResponseDto>>> ListUsersAsync(ListUsersRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListUsersAsync));
        try
        {
            bool isEmail = CriptografiaHelper.VerifyEmail(request.Email);
		
            var users = isEmail 
                ? await _userManager.Users.Where(u => u.Email.Contains(request.Email)).ToListAsync() 
                : await _userManager.Users.Where(u => u.UserName.Contains(request.Email)).ToListAsync();
            
            var data = new List<ListUsersResponseDto>();
            
            foreach (var user in users)
            {
                var userDto = new ListUsersResponseDto
                {

                    Email = user.Email,
                    UserName = user.UserName,
                };
                data.Add(userDto);
            }
            
            if (data.Count == 0)
            {
                return ResponseDto<IEnumerable<ListUsersResponseDto>>.Fail("Nenhum usuario encontrado.", HttpStatusCode.Found);
            }
            else
            {
                return ResponseDto<IEnumerable<ListUsersResponseDto>>.Sucess(data.ToList());
            }
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListUsersResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListUsersAsync));
        }
    }
}
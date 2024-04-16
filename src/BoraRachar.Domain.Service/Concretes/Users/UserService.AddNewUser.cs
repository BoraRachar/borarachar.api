using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.AddNewUser;
using BoraRachar.Domain.Utils;
using BoraRachar.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> AddNewUserAsync(AddNewUserRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddNewUserAsync));
        try
        {
            var result = await _userManager.Users.Where(u => u.Email == request.Email).FirstOrDefaultAsync();

            if (result != null)
            {
                return ResponseDto.Fail("Usuário já cadastrado", HttpStatusCode.BadRequest);
            }

            bool isValidPass = Validators.ValidatePassword(request.Password);

            if (isValidPass.Equals(false))
            {
                return ResponseDto.Fail("A senha deve conter 1 letra Maiuscula, 1 Minuscula e 1 caracter especial", HttpStatusCode.BadRequest);
            }

            if (request.TermosUso.Equals(false))
            {
                return ResponseDto.Fail("Por favor aceite os Termos de Uso", HttpStatusCode.BadRequest);
            }
            if (request.PoliticasPrivacidade.Equals(false))
            {
                return ResponseDto.Fail("Por favor, Leia as Politicas de Privacidade", HttpStatusCode.BadRequest);
            }

            var entityUser = _mapper.Map<User>(request);

            var resultCreate = await _userManager.CreateAsync(new User(entityUser.Email), request.Password);
            if (!resultCreate.Succeeded)
            {
                return ResponseDto.Fail($"Falha ao cadastrar usuário:{resultCreate.Errors.FirstOrDefault()}", HttpStatusCode.BadRequest);
            }
            var user = await _userManager.FindByEmailAsync(request.Email);

            return ResponseDto.Sucess("Cadastrado com sucesso", HttpStatusCode.Created);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddNewUserAsync));
        }
    }
}

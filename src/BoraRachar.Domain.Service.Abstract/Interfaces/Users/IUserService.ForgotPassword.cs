using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ForgotPassword;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService
{
    Task<ResponseDto<None>> ForgotPasswordAsync(ForgotPasswordRequestDto request, CancellationToken cancellationToken);
}

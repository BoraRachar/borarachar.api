using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ConfirmEmail;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService
{
	Task<ResponseDto<None>> ConfimEmailAsync(ConfirmEmailRequestDto request, CancellationToken cancellationToken);
}

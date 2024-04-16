using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.UpdateUser;
using BoraRachar.Domain.Service.Abstract.Interfaces.Bases;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService : IBaseService
{
    Task<ResponseDto<None>> UpdateUserAsync(UpdateUserRequestDto request, CancellationToken cancellationToken);
}

using BoraRachar.Domain.Service.Abstract.Interfaces.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.AddNewUser;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService : IBaseService
{
    Task<ResponseDto<None>> AddNewUserAsync(AddNewUserRequestDto request, CancellationToken cancellationToken);
}

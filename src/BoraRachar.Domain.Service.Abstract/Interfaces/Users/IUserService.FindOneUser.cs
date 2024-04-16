using BoraRachar.Domain.Service.Abstract.Interfaces.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindOneUser;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService : IBaseService
{
    Task<ResponseDto<FindOneUserResponseDto>> FindOneUserAsync(FindOneUserRequestDto requestDto, CancellationToken cancellationToken = default);
}

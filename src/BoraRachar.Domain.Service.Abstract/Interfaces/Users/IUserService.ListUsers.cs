using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ListUsers;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService
{
    Task<ResponseDto<IEnumerable<ListUsersResponseDto>>> ListUsersAsync(ListUsersRequestDto requestDto, CancellationToken cancellationToken = default);
}
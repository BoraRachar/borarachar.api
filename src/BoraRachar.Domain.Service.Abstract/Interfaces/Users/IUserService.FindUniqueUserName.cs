using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindUniqueUserName;
using BoraRachar.Domain.Service.Abstract.Interfaces.Bases;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService: IBaseService
{
    Task<ResponseDto<FindUniqueUserNameResponseDto>> FindUniqueUserNameAsync(FindUniqueUserNameRequestDto requestDto, CancellationToken cancellationToken = default);
}
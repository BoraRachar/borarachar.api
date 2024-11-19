using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ListUsers;
using MediatR;

namespace BoraRachar.Application.UserCases.User.ListUsers;

public class ListUsersRequest : ListUsersRequestDto, IRequest<ResponseDto<IEnumerable<ListUsersResponseDto>>>
{
    
}
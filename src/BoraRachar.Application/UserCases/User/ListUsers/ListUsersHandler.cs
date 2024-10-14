using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ListUsers;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using MediatR;

namespace BoraRachar.Application.UserCases.User.ListUsers;

public class ListUsersHandler: IRequestHandler<ListUsersRequest, ResponseDto<IEnumerable<ListUsersResponseDto>>>
{
    private readonly IUserService _userService;
    public ListUsersHandler(IUserService userService) => _userService = userService;
    public Task<ResponseDto<IEnumerable<ListUsersResponseDto>>> Handle(ListUsersRequest request, CancellationToken cancellationToken)
    {
        return _userService.ListUsersAsync(request, cancellationToken);
    }
}
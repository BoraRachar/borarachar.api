using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindUniqueUserName;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using MediatR;

namespace BoraRachar.Application.UserCases.User.FindUniqueUserName;

public class FindUniqueUserNameHandler : IRequestHandler<FindUniqueUserNameRequest, ResponseDto<FindUniqueUserNameResponseDto>>
{
    private readonly IUserService _userService;

    public FindUniqueUserNameHandler(IUserService userService) => _userService = userService;
     
    public async Task<ResponseDto<FindUniqueUserNameResponseDto>> Handle(FindUniqueUserNameRequest request, CancellationToken cancellationToken)
    {
        return await _userService.FindUniqueUserNameAsync(request, cancellationToken);
    }

}
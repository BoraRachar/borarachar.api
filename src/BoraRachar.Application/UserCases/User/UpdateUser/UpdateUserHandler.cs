using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, ResponseDto<None>>
{
    private readonly IUserService _userService;

    public UpdateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<ResponseDto<None>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        return _userService.UpdateUserAsync(request, cancellationToken);
    }
}

using MediatR;
using BoraRachar.Application.UserCases.User.CreateNewUser;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.Users.CreateNewUser;

public class CreateNewUserHandler : IRequestHandler<CreateNewUserRequest, ResponseDto<None>>
{
    private readonly IUserService _userService;

    public CreateNewUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ResponseDto<None>> Handle(CreateNewUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.AddNewUserAsync(request, cancellationToken);
    }
}
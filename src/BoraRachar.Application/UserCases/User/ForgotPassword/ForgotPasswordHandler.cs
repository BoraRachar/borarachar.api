using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.ForgotPassword;

public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordRequest, ResponseDto<None>>
{
    private readonly IUserService _userService;

    public ForgotPasswordHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<ResponseDto<None>> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
    {
        return _userService.ForgotPasswordAsync(request, cancellationToken);
    }
}

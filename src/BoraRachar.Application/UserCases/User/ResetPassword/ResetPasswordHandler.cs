using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.UserCases.User.ResetPassword;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResponseDto<None>>
{
    private readonly IUserService _userService;

    public ResetPasswordHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<ResponseDto<None>> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        return _userService.ResetPasswordAsync(request, cancellationToken);
    }
}

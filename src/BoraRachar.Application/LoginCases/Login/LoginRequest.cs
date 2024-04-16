using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Token.UserLoginResponse;

namespace BoraRachar.Application.LoginCases.Login;

public class LoginRequest : UserLoginRequestDto, IRequest<ResponseDto<UserLoginResponseDto>>
{
}

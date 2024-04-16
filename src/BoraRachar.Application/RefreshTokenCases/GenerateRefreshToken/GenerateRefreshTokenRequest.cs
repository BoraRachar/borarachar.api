using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Token.SecurityToken;
using BoraRachar.Domain.Service.Abstract.Dtos.Token.UserLoginResponse;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.RefreshTokenCases.GenerateRefreshToken
{
    public class GenerateRefreshTokenRequest : SecurityTokenRequestDto, IRequest<ResponseDto<UserLoginResponseDto>>
    {
    }
}


using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ForgotPassword;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.ForgotPassword;

public class ForgotPasswordRequest : ForgotPasswordRequestDto, IRequest<ResponseDto<None>>
{
}

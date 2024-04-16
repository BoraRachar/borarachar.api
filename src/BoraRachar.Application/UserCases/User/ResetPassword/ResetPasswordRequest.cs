using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ResetPassword;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.ResetPassword;

public class ResetPasswordRequest : ResetPasswordRequestDto, IRequest<ResponseDto<None>>
{
}



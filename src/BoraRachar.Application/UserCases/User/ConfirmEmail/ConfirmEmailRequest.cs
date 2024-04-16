using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ConfirmEmail;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.ConfirmEmail;

public class ConfirmEmailRequest : ConfirmEmailRequestDto, IRequest<ResponseDto<None>>
{
}

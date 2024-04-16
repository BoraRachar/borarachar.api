using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.UpdateUser;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.UpdateUser;

public class UpdateUserRequest : UpdateUserRequestDto, IRequest<ResponseDto<None>>
{
}

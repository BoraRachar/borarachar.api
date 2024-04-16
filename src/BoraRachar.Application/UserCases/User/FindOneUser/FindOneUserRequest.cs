using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindOneUser;

namespace BoraRachar.Application.UserCases.User.FindOneUser;

public class FindOneUserRequest : FindOneUserRequestDto, IRequest<ResponseDto<FindOneUserResponseDto>>
{

}
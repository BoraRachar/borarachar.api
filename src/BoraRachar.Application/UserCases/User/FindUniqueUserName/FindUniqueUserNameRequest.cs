using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindUniqueUserName;
using MediatR;

namespace BoraRachar.Application.UserCases.User.FindUniqueUserName;

public class FindUniqueUserNameRequest: FindUniqueUserNameRequestDto, IRequest<ResponseDto<FindUniqueUserNameResponseDto>>
{
    
}
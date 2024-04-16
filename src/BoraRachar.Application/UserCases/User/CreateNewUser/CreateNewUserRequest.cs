using MediatR;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.AddNewUser;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Application.UserCases.User.CreateNewUser;

public class CreateNewUserRequest : AddNewUserRequestDto, IRequest<ResponseDto<None>>
{
}
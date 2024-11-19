using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Convites.Reenviar;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.ConviteCases.Reenviar;

public class ReenviarRequest: ReenviarRequestDto, IRequest<ResponseDto<None>>
{
    
}
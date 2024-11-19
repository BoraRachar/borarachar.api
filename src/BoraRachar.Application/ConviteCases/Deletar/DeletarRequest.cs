using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Convites.Reenviar;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.ConviteCases.Deletar;

public class DeletarRequest: ReenviarRequestDto, IRequest<ResponseDto<None>>
{
    
}
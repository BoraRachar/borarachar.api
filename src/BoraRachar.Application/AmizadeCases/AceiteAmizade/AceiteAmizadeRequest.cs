using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.Aceite;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.AceiteAmizade;

public class AceiteAmizadeRequest: AceiteRequestDto, IRequest<ResponseDto<None>>
{
    
}
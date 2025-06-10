using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.ParticipantesCases.IsAdm;

public class IsAdmRequest: IsAdmRequestDto, IRequest<ResponseDto<None>>
{
    
}


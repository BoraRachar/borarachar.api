using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using MediatR;

namespace BoraRachar.Application.ParticipantesCases.ListParticipantes;

public class ListParticipantesRequest: ListParticipantesRequestDto, IRequest<ResponseDto<IEnumerable<ListParticipantesResponseDto>>>
{
    
}
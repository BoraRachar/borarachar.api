using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using BoraRachar.Domain.Service.Abstract.Interfaces.Participantes;
using MediatR;

namespace BoraRachar.Application.ParticipantesCases.ListParticipantes;

public class ListParticipantesHandler: IRequestHandler<ListParticipantesRequest, ResponseDto<IEnumerable<ListParticipantesResponseDto>>>
{
    private readonly IParticipantesService _participantesService;

    public ListParticipantesHandler(IParticipantesService participantesService) => _participantesService = participantesService;
    public async Task<ResponseDto<IEnumerable<ListParticipantesResponseDto>>> Handle(ListParticipantesRequest request, CancellationToken cancellationToken)
    {
        return await _participantesService.ListParticipantesAsync(request, cancellationToken); 
    }
}
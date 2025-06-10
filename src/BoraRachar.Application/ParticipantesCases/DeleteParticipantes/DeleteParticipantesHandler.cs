using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Participantes;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.ParticipantesCases.DeleteParticipantes;

public class DeleteParticipantesHandler: IRequestHandler<DeleteParticipantesRequest, ResponseDto<None>>
{
    private readonly IParticipantesService _participantesService;

    public DeleteParticipantesHandler(IParticipantesService participantesService) => _participantesService = participantesService;
    public async Task<ResponseDto<None>> Handle(DeleteParticipantesRequest request, CancellationToken cancellationToken)
    {
        return await _participantesService.DeleteParticipantesAsync(request, cancellationToken); 
    }
}
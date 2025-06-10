using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Participantes;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.ParticipantesCases.AddParticipantes;

public class AddParticipantesHandler: IRequestHandler<AddParticipantesRequest, ResponseDto<None>>
{
    private readonly IParticipantesService _participantesService;

    public AddParticipantesHandler(IParticipantesService participantesService) => _participantesService = participantesService;
    public async Task<ResponseDto<None>> Handle(AddParticipantesRequest request, CancellationToken cancellationToken)
    {
        return await _participantesService.AddParticipantesAsync(request, cancellationToken); 
    }
}
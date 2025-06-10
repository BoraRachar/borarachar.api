using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Participantes;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.ParticipantesCases.IsAdm;

public class IsAdmHandler: IRequestHandler<IsAdmRequest, ResponseDto<None>>
{
    private readonly IParticipantesService _participantesService;

    public IsAdmHandler(IParticipantesService participantesService) => _participantesService = participantesService;
    public async Task<ResponseDto<None>> Handle(IsAdmRequest request, CancellationToken cancellationToken)
    {
        return await _participantesService.IsAdmAsync(request, cancellationToken); 
    }
}
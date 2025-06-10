using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Participantes;

public partial interface IParticipantesService
{
    public Task<ResponseDto<None>> DeleteParticipantesAsync(AddParticipantesRequestDto request, CancellationToken cancellation);
}

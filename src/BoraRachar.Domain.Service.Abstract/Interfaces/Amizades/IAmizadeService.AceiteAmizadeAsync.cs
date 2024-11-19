using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.Aceite;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;

public partial interface IAmizadeService
{
    Task<ResponseDto<None>> AceiteAmizadeAsync(AceiteRequestDto request, CancellationToken cancellationToken);
}


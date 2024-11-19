using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.Aceite;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListAmizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListConvites;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;

public partial interface IAmizadeService
{
    Task<ResponseDto<IEnumerable<ListAmizadesResponseDto>>> ListAmizadesAsync(ListAmizadesRequestDto request, CancellationToken cancellationToken);
}


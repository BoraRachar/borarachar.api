using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListAmizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.ListPendencias;

public class ListPendenciasHandler: IRequestHandler<ListPendenciasRequest, ResponseDto<IEnumerable<ListPendenciasAmizadesResponseDto>>>
{
    private readonly IAmizadeService _amizadeService;

    public ListPendenciasHandler(IAmizadeService amizadeService) => _amizadeService = amizadeService;
    public async Task<ResponseDto<IEnumerable<ListPendenciasAmizadesResponseDto>>> Handle(ListPendenciasRequest request, CancellationToken cancellationToken)
    {
        return await _amizadeService.ListPendenciasAmizadesAsync(request, cancellationToken);
    }
}
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListAmizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.ListAmizades;

public class ListAmizadesHandler: IRequestHandler<ListAmizadesRequest, ResponseDto<IEnumerable<ListAmizadesResponseDto>>>
{
    private readonly IAmizadeService _amizadeService;
    public ListAmizadesHandler(IAmizadeService amizadeService) => _amizadeService = amizadeService;
  
    public async Task<ResponseDto<IEnumerable<ListAmizadesResponseDto>>> Handle(ListAmizadesRequest request, CancellationToken cancellationToken)
    {
        return await _amizadeService.ListAmizadesAsync(request, cancellationToken);
    }
}
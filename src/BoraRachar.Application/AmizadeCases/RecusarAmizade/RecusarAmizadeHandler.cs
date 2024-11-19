using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.RecusarAmizade;

public class RecusarAmizadeHandler: IRequestHandler<RecusarAmizadeRequest, ResponseDto<None>>
{
    private readonly IAmizadeService _amizadeService;
    public RecusarAmizadeHandler(IAmizadeService amizadeService) => _amizadeService = amizadeService;
    
    public async Task<ResponseDto<None>> Handle(RecusarAmizadeRequest request, CancellationToken cancellationToken)
    {
        return await _amizadeService.RecusarAmizadeAsync(request, cancellationToken);
    }
}
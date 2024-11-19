using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.AceiteAmizade;

public class AceiteAmizadeHandler: IRequestHandler<AceiteAmizadeRequest, ResponseDto<None>>
{
    private readonly IAmizadeService _amizadeService;

    public AceiteAmizadeHandler(IAmizadeService amizadeService) => _amizadeService = amizadeService;
    public async Task<ResponseDto<None>> Handle(AceiteAmizadeRequest request, CancellationToken cancellationToken)
    {
        return await _amizadeService.AceiteAmizadeAsync(request, cancellationToken);
    }
}
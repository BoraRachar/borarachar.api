using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.GetDespesa;
using BoraRachar.Domain.Service.Abstract.Interfaces.Despesas;
using MediatR;

namespace BoraRachar.Application.DespesaCases.GetDespesa;

public class GetDespesaHandler: IRequestHandler<GetDespesaRequest, ResponseDto<GetDespesaResponseDto>>
{
    private readonly IDespesaService _despesaService;
    public GetDespesaHandler(IDespesaService despesaService) => _despesaService = despesaService;
    public async Task<ResponseDto<GetDespesaResponseDto>> Handle(GetDespesaRequest request, CancellationToken cancellationToken)
    {
        return await _despesaService.GetDespesaAsync(request, cancellationToken); 
    }
}
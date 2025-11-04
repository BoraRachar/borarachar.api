using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.ListDespesas;
using BoraRachar.Domain.Service.Abstract.Interfaces.Despesas;
using MediatR;

namespace BoraRachar.Application.DespesaCases.ListDespesas;

public class ListDespesasHandler: IRequestHandler<ListDespesasRequest,ResponseDto<IEnumerable<ListDespesasResponseDto>>>
{
    private readonly IDespesaService _despesaService;

    public ListDespesasHandler(IDespesaService despesaService) => _despesaService = despesaService;
    public async Task<ResponseDto<IEnumerable<ListDespesasResponseDto>>> Handle(ListDespesasRequest request, CancellationToken cancellationToken)
    {
        return await _despesaService.ListDespesasAsync(request, cancellationToken); 
    }
}
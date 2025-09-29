using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Despesas;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.DespesaCases.AddDespesa;

public class AddDespesaHandler: IRequestHandler<AddDespesaRequest, ResponseDto<None>>
{
    private readonly IDespesaService _despesaService;

    public AddDespesaHandler(IDespesaService despesaService) => _despesaService = despesaService;
    
    public async Task<ResponseDto<None>> Handle(AddDespesaRequest request, CancellationToken cancellationToken)
    {
        return await _despesaService.CreateDespesaAsync(request, cancellationToken); 
    }
}
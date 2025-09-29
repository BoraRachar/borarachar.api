using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.AddDespesa;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Despesas;

public interface IDespesaService
{
    public Task<ResponseDto<None>> CreateDespesaAsync(AddDespesaRequestDto request, CancellationToken cancellation);
}
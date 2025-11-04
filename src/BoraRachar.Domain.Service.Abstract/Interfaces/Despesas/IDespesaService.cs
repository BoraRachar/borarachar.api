using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.AddDespesa;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.GetDespesa;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.ListDespesas;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Despesas;

public interface IDespesaService
{
    public Task<ResponseDto<None>> CreateDespesaAsync(AddDespesaRequestDto request, CancellationToken cancellation);
    public Task<ResponseDto<IEnumerable<ListDespesasResponseDto>>> ListDespesasAsync(ListDespesasRequestDto request, CancellationToken cancellation);
    public Task<ResponseDto<GetDespesaResponseDto>> GetDespesaAsync(GetDespesaRequestDto request, CancellationToken cancellation);
}
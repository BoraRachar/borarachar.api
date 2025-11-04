using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.ListDespesas;
using MediatR;

namespace BoraRachar.Application.DespesaCases.ListDespesas;

public class ListDespesasRequest: ListDespesasRequestDto, IRequest<ResponseDto<IEnumerable<ListDespesasResponseDto>>>
{
    
}
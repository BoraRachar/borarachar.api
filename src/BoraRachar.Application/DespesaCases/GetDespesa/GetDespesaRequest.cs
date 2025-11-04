using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.GetDespesa;
using MediatR;

namespace BoraRachar.Application.DespesaCases.GetDespesa;

public class GetDespesaRequest: GetDespesaRequestDto, IRequest<ResponseDto<GetDespesaResponseDto>>
{
    public GetDespesaRequest()
    {
        
    }
}
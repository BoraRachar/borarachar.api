using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.AddDespesa;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.DespesaCases.AddDespesa;

public class AddDespesaRequest: AddDespesaRequestDto, IRequest<ResponseDto<None>>
{
    
}
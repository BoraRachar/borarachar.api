using BoraRachar.Domain.Service.Abstract.Dtos.Atividades.ListaAtividades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using MediatR;

namespace BoraRachar.Application.AtividadeCases.ListaAtividades;

public class ListaAtividadesRequest: ListaAtividadesRequestDto, IRequest<ResponseDto<IEnumerable<ListaAtividadesResponseDto>>>
{
    public ListaAtividadesRequest()
    {
        
    }
}
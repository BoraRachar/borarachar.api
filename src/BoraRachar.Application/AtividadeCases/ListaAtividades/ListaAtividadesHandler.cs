using BoraRachar.Domain.Service.Abstract.Dtos.Atividades.ListaAtividades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Atividades;
using MediatR;

namespace BoraRachar.Application.AtividadeCases.ListaAtividades;

public class ListaAtividadesHandler: IRequestHandler<ListaAtividadesRequest, ResponseDto<IEnumerable<ListaAtividadesResponseDto>>>
{
    private readonly IAtividadeService _atividadeService;

    public ListaAtividadesHandler(IAtividadeService atividadeService) => _atividadeService = atividadeService;
   
    public async Task<ResponseDto<IEnumerable<ListaAtividadesResponseDto>>> Handle(ListaAtividadesRequest request, CancellationToken cancellationToken)
    {
        return await _atividadeService.ListAtividadesAsync(request, cancellationToken);
    }
}
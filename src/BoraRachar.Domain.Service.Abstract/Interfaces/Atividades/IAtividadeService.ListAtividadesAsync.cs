using BoraRachar.Domain.Service.Abstract.Dtos.Atividades.ListaAtividades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Atividades;

public partial interface IAtividadeService
{
    Task<ResponseDto<IEnumerable<ListaAtividadesResponseDto>>> ListAtividadesAsync(ListaAtividadesRequestDto request, CancellationToken cancellationToken = default);
}
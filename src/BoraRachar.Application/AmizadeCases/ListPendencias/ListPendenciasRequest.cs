using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListAmizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.ListPendencias;

public class ListPendenciasRequest: ListAmizadesRequestDto, IRequest<ResponseDto<IEnumerable<ListPendenciasAmizadesResponseDto>>>
{
    
}
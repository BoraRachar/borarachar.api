using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListAmizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.ListAmizades;

public class ListAmizadesRequest: ListAmizadesRequestDto, IRequest<ResponseDto<IEnumerable<ListAmizadesResponseDto>>>
{
    
}
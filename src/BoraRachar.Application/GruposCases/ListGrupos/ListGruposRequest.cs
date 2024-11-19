using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.AddGrupo;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListGroups;
using MediatR;

namespace BoraRachar.Application.GruposCases.ListGrupos;

public class ListGruposRequest: ListGroupRequestDto, IRequest<ResponseDto<IEnumerable<ListGroupResponseDto>>>
{
    
}
using BoraRachar.Application.GruposCases.AdicionarGrupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListGroups;
using BoraRachar.Domain.Service.Abstract.Interfaces.Groups;
using MediatR;

namespace BoraRachar.Application.GruposCases.ListGrupos;

public class ListGruposHandler: IRequestHandler<ListGruposRequest, ResponseDto<IEnumerable<ListGroupResponseDto>>>
{
    private readonly IGroupService _groupService;

    public ListGruposHandler(IGroupService groupService) => _groupService = groupService;
    
    public async Task<ResponseDto<IEnumerable<ListGroupResponseDto>>> Handle(ListGruposRequest request, CancellationToken cancellationToken)
    {
        return await _groupService.ListGroupsAsync(request, cancellationToken); 
    }
    
}
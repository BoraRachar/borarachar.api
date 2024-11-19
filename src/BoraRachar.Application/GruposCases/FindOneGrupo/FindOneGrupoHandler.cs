using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.FindOneGrupo;
using BoraRachar.Domain.Service.Abstract.Interfaces.Groups;
using MediatR;

namespace BoraRachar.Application.GruposCases.FindOneGrupo;

public class FindOneGrupoHandler: IRequestHandler<FindOneGrupoRequest, ResponseDto<FindOneGrupoResponseDto>>
{
    private readonly IGroupService _groupService;
    public FindOneGrupoHandler(IGroupService groupService) => _groupService = groupService;
    public async Task<ResponseDto<FindOneGrupoResponseDto>> Handle(FindOneGrupoRequest request, CancellationToken cancellationToken)
    {
        return await _groupService.FindOneGroupAsync(request, cancellationToken); 
    }
}
using System;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListarGrupo;
using BoraRachar.Domain.Service.Abstract.Interfaces.Groups;
using MediatR;

namespace BoraRachar.Application.GruposCases.ListarGrupo;

public class ListarGrupoHandler : IRequestHandler<ListarGrupoRequest, ResponseDto<IEnumerable<ListarGrupoResponseDto>>>
{
    private readonly IGroupService _groupService;

    public ListarGrupoHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }


    public async Task<ResponseDto<IEnumerable<ListarGrupoResponseDto>>> Handle(ListarGrupoRequest request, CancellationToken cancellationToken)
    {
        return await _groupService.ListarGruposAsync(request, cancellationToken);
    }
}

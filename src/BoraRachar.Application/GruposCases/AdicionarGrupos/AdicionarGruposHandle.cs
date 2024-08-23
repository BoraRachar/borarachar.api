using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Groups;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.GruposCases.AdicionarGrupos;

public class AdicionarGruposHandler : IRequestHandler<AdicionarGrupoRequest, ResponseDto<None>>
{
    private readonly IGroupService _groupService;

    public AdicionarGruposHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public async Task<ResponseDto<None>> Handle(AdicionarGrupoRequest request, CancellationToken cancellationToken)
    {
        return await _groupService.CreateNewGroup(request, cancellationToken); 
    }
}
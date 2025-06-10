using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Groups;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.GruposCases.UpdateGrupos;

public class UpdateGruposHandler: IRequestHandler<UpdateGruposRequest, ResponseDto<None>>
{
    private readonly IGroupService _groupService;

    public UpdateGruposHandler(IGroupService groupService) => _groupService = groupService;
    public async Task<ResponseDto<None>> Handle(UpdateGruposRequest request, CancellationToken cancellationToken)
    {
        return await _groupService.UpdateGroupAsync(request, cancellationToken); 
    }
}
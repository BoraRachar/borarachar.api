using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.AddGrupo;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Groups;

public partial interface IGroupService
{
    public Task<ResponseDto<None>> CreateNewGroup(AddGrupoRequestDto request, CancellationToken cancellation);
}
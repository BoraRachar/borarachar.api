using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupo.AdicionarGrupo;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Groups;

public partial interface IGroupService
{
    public Task<ResponseDto<None>> CreateNewGroup(AdicionarGrupoRequestDto grupos, CancellationToken cancellation);
}
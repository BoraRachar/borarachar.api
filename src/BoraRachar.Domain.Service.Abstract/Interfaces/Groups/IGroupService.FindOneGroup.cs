using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.FindOneGrupo;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Groups;

public partial interface IGroupService
{
    public Task<ResponseDto<FindOneGrupoResponseDto>> FindOneGroupAsync(FindOneGrupoRequestDto request, CancellationToken cancellation);
}
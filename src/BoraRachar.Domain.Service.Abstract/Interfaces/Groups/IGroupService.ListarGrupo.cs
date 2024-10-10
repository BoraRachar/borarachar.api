using System;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListarGrupo;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Groups;

public partial interface IGroupService
{
    public Task<ResponseDto<IEnumerable<ListarGrupoResponseDto>>> ListarGruposAsync(ListarGrupoRequestDto request, CancellationToken cancellationToken);
}

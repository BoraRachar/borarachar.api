using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListarGrupo;
using MediatR;

namespace BoraRachar.Application.GruposCases.ListarGrupo;

public class ListarGrupoRequest : ListarGrupoRequestDto, IRequest<ResponseDto<IEnumerable<ListarGrupoResponseDto>>>
{

}

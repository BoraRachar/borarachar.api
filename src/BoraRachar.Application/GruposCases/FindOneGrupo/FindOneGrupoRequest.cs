using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.FindOneGrupo;
using MediatR;

namespace BoraRachar.Application.GruposCases.FindOneGrupo;

public class FindOneGrupoRequest: FindOneGrupoRequestDto, IRequest<ResponseDto<FindOneGrupoResponseDto>>
{
    
}
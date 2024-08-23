using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupo.AdicionarGrupo;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.GruposCases.AdicionarGrupos;

public class AdicionarGrupoRequest : AdicionarGrupoRequestDto, IRequest<ResponseDto<None>>
{

}
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.AddGrupo;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.GruposCases.AdicionarGrupos;

public class AdicionarGrupoRequest : AddGrupoRequestDto, IRequest<ResponseDto<None>>
{

}
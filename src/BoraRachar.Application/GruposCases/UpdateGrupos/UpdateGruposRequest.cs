using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.UpdateGrupo;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.GruposCases.UpdateGrupos;

public class UpdateGruposRequest: UpdateGrupoRequestDto, IRequest<ResponseDto<None>>
{
    
}
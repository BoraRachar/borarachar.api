using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.GruposCases.AdicionarGrupos;

public class AdicionarGrupoRequest : AddCategoriaRequestDto, IRequest<ResponseDto<None>>
{

}
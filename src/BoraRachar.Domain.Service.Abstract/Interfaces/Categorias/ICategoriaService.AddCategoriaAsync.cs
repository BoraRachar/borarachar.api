using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Categorias;

public partial interface ICategoriaService
{
    Task<ResponseDto<None>> AddCategoriaAsync(AddCategoriaRequestDto request, CancellationToken cancellationToken);
}
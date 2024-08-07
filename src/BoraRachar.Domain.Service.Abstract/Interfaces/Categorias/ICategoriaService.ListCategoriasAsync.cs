using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.ListCategorias;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Categorias;

public partial interface ICategoriaService
{
    Task<ResponseDto<IEnumerable<ListCategoriasResponseDto>>> ListCategoriasAsync(ListCategoriasRequestDto request, CancellationToken cancellationToken);
}
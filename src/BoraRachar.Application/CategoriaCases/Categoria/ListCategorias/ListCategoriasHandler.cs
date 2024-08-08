using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.ListCategorias;
using BoraRachar.Domain.Service.Abstract.Interfaces.Categorias;
using MediatR;

namespace BoraRachar.Application.CategoriaCases.Categoria.ListCategorias;

public class ListCategoriasHandler: IRequestHandler<ListCategoriasRequest, ResponseDto<IEnumerable<ListCategoriasResponseDto>>>
{
    private readonly ICategoriaService _categoriaService;
    public ListCategoriasHandler(ICategoriaService categoriaService) => _categoriaService = categoriaService;
   
    public async Task<ResponseDto<IEnumerable<ListCategoriasResponseDto>>> Handle(ListCategoriasRequest request, CancellationToken cancellationToken)
    {
        return await _categoriaService.ListCategoriasAsync(request, cancellationToken);
    }
}
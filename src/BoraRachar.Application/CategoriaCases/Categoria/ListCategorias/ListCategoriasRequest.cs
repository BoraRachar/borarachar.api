using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.ListCategorias;
using MediatR;

namespace BoraRachar.Application.CategoriaCases.Categoria.ListCategorias;

public class ListCategoriasRequest: ListCategoriasRequestDto, IRequest<ResponseDto<IEnumerable<ListCategoriasResponseDto>>>
{
    
}
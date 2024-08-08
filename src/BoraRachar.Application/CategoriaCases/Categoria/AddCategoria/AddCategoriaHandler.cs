using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Categorias;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.CategoriaCases.Categoria.AddCategoria;

public class AddCategoriaHandler: IRequestHandler<AddCategoriaRequest, ResponseDto<None>>
{
    private readonly ICategoriaService _categoriaService;

    public AddCategoriaHandler(ICategoriaService categoriaService) => _categoriaService = categoriaService;
    public async Task<ResponseDto<None>> Handle(AddCategoriaRequest request, CancellationToken cancellationToken)
    {
        return await _categoriaService.AddCategoriaAsync(request, cancellationToken);
    }
}
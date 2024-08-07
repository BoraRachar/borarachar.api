using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.CategoriaCases.Categoria.AddCategoria;

public class AddCategoriaRequest: AddCategoriaRequestDto, IRequest<ResponseDto<None>>
{
    
}
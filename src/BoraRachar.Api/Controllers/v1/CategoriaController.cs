using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.CategoriaCases.Categoria.AddCategoria;
using BoraRachar.Application.CategoriaCases.Categoria.ListCategorias;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.ListCategorias;
using BoraRachar.Infra.CrossCuting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class CategoriaController: ApiControllerBase
{
    private readonly IMediator _mediator;

    public CategoriaController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostCategoria([FromBody] AddCategoriaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("lista-categoria")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListCategoriasResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostCategoria([FromQuery] ListCategoriasRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }    
}
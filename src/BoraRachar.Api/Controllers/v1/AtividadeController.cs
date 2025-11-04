using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.AtividadeCases.ListaAtividades;
using BoraRachar.Domain.Service.Abstract.Dtos.Atividades.ListaAtividades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class AtividadeController : ApiControllerBase
{
    private readonly IMediator _mediator;
    public AtividadeController(IMediator mediator) => _mediator = mediator;
     
    [HttpGet("lista-atividades")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListaAtividadesResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListaAtividadesAsync([FromQuery] ListaAtividadesRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }   
}
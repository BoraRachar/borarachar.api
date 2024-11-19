using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.AmizadeCases.AceiteAmizade;
using BoraRachar.Application.AmizadeCases.AddAmigo;
using BoraRachar.Application.AmizadeCases.AddAmigoEmail;
using BoraRachar.Application.AmizadeCases.ListAmizades;
using BoraRachar.Application.AmizadeCases.ListConvites;
using BoraRachar.Application.AmizadeCases.ListPendencias;
using BoraRachar.Application.AmizadeCases.RecusarAmizade;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListAmizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListConvites;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class AmizadeController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public AmizadeController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("add-amigo")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAmigoAsync([FromBody] AddAmigoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("add-amigo-email")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAmigoEmailAsync([FromBody] AddAmigoEmailRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("aceite-amizade")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AceiteAmizadeAsync([FromBody] AceiteAmizadeRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpDelete("recusar-amizade")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AceiteAmizadeAsync([FromBody] RecusarAmizadeRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-amizades")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListAmizadesResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListaAmizadesAsync([FromQuery] ListAmizadesRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }   
    [HttpGet("lista-pendencias-amizades")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListPendenciasAmizadesResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListaPendenciasAmizadesAsync([FromQuery] ListPendenciasRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }  
}
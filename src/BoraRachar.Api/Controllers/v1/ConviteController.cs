using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.AmizadeCases.ListConvites;
using BoraRachar.Application.ConviteCases.Deletar;
using BoraRachar.Application.ConviteCases.Reenviar;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListConvites;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class ConviteController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ConviteController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("reenviar")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ReenviarConviteAsync([FromQuery] ReenviarRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }  
    
    [HttpDelete("deletar")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletarConviteAsync([FromQuery] DeletarRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }  
    
    [HttpGet("lista-convites")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListConvitesResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListConvitesAsync([FromQuery] ListConvitesRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }  
}
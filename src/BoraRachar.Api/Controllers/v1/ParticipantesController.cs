using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.ParticipantesCases.AddParticipantes;
using BoraRachar.Application.ParticipantesCases.DeleteParticipantes;
using BoraRachar.Application.ParticipantesCases.IsAdm;
using BoraRachar.Application.ParticipantesCases.ListParticipantes;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using BoraRachar.Infra.CrossCuting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class ParticipantesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ParticipantesController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet("lista-participantes")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListParticipantesResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListaParticipantes([FromQuery] ListParticipantesRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddParticipantes([FromBody] AddParticipantesRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }  
    
    [HttpDelete("delete-participantes")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteParticipantes([FromBody] DeleteParticipantesRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}
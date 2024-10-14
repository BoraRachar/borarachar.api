using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.GruposCases.AdicionarGrupos;
using BoraRachar.Application.GruposCases.FindOneGrupo;
using BoraRachar.Application.GruposCases.ListGrupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.FindOneGrupo;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListGroups;
using BoraRachar.Infra.CrossCuting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class GruposController : ApiControllerBase
{
    private readonly IMediator _mediator;
    public GruposController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CriarNovoGrupo([FromBody] AdicionarGrupoRequest grupoRequest)
    {
        var response = await _mediator.Send(grupoRequest);
        return CreateResult(response);
    }
    
    [HttpGet("detalhes-grupo")]
    [ProducesResponseType(typeof(ResponseDto<FindOneGrupoResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> FindOneGrupo([FromQuery] FindOneGrupoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    

    [HttpGet("lista-grupos")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListGroupResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListGrupos([FromQuery] ListGruposRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }   
}
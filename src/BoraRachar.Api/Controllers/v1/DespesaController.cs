using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.DespesaCases.AddDespesa;
using BoraRachar.Application.DespesaCases.GetDespesa;
using BoraRachar.Application.DespesaCases.ListDespesas;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.GetDespesa;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.ListDespesas;
using BoraRachar.Infra.CrossCuting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class DespesaController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DespesaController(IMediator mediator) => _mediator = mediator;
   
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddDespesaAsync([FromBody] AddDespesaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-despesas")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListDespesasResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListDespesasAsync([FromQuery] ListDespesasRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet()]
    [ProducesResponseType(typeof(ResponseDto<GetDespesaResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDespesaAsync([FromQuery] GetDespesaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}
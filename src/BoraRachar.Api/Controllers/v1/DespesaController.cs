using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.DespesaCases.AddDespesa;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
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
}
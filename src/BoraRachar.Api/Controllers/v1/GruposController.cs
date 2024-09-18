using System.Security.Claims;
using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.GruposCases.AdicionarGrupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class GruposController : ApiControllerBase
{
    private readonly IMediator _mediator;
    public GruposController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
 
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CriarNovoGrupo([FromBody] AdicionarGrupoRequest grupoRequest)
    {
        // var identity = HttpContext.User.Identity as ClaimsIdentity;
        // if (identity != null)
        // {
        //     IEnumerable<Claim> claims = identity.Claims;
        //     // var test = identity.FindFirst("teste").Value;
        // }
        
        var response = await _mediator.Send(grupoRequest);
        return CreateResult(response);
    }
}
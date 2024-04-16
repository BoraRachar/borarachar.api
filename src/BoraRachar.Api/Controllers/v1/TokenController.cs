using MediatR;
using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.RefreshTokenCases.GenerateRefreshToken;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Token.UserLoginResponse;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class TokenController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public TokenController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(ResponseDto<UserLoginResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RefreshToken([FromQuery] GenerateRefreshTokenRequest token)
    {
        var response = await _mediator.Send(token);
        return CreateResult(response);
    }
}

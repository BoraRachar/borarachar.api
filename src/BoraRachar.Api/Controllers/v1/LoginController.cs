using MediatR;
using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.LoginCases.Login;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Token.UserLoginResponse;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

public class LoginController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseDto<UserLoginResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}

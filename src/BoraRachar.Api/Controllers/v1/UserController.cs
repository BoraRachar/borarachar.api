using BoraRachar.Api.Controllers.Bases;
using BoraRachar.Application.UserCases.User.CreateNewUser;
using BoraRachar.Application.UserCases.User.FindOneUser;
using BoraRachar.Application.UserCases.User.FindUniqueUserName;
using BoraRachar.Application.UserCases.User.ForgotPassword;
using BoraRachar.Application.UserCases.User.ListUsers;
using BoraRachar.Application.UserCases.User.ResetPassword;
using BoraRachar.Application.UserCases.User.UpdateUser;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.AddNewUser;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindOneUser;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindUniqueUserName;
using BoraRachar.Domain.Service.Abstract.Dtos.User.ListUsers;
using BoraRachar.Infra.CrossCuting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.v1;

//[Authorize("Bearer")]
public class UserController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseDto<FindOneUserResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var response = await _mediator.Send(new FindOneUserRequest { Id = id });
        return CreateResult(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseDto<AddNewUserRequestDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostUser([FromBody] CreateNewUserRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutUser([FromBody] UpdateUserRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }

    [HttpGet("find-usuario")]
    [ProducesResponseType(typeof(ResponseDto<FindUniqueUserNameResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetForgotPassword([FromQuery] FindUniqueUserNameRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }

    [HttpGet("forgot-password")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetForgotPassword([FromQuery] ForgotPasswordRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }

    [HttpPost("reset-password")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostResetPassword([FromBody] ResetPasswordRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("list-usuarios")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListUsersResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult>? ListUsuarios([FromQuery] ListUsersRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }   
}
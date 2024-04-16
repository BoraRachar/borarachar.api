using System.Net;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.Bases;

public class ApiExceptionController : ApiResultController
{
    [Route("/error"), HttpGet("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetError([FromServices] IWebHostEnvironment env)
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var status = (HttpStatusCode)HttpContext.Response.StatusCode;
        var response = ResponseDto.Fail(ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(context?.Error.Message)
                .WithStackTrace(context?.Error.StackTrace)
                .WithException(context?.Error.ToString())
                .WithErrorCode(HttpContext.Response.StatusCode.ToString()),
            (HttpStatusCode)HttpContext.Response.StatusCode
        );

        return CreateResult(response, status);
    }
}
using BoraRachar.Api.Extensions;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BoraRachar.Api.Filters;

public class ValidatorFilter : IAsyncActionFilter
{

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(ResponseDto<None>.Fail(context.ModelState.GetErrors()));
            return;
        }

        await next().ConfigureAwait(false);
    }
}
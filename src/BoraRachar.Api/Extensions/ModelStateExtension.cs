using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BoraRachar.Api.Extensions;

public static class ModelStateExtension
{
    public static List<ErrorResponse> GetErrors(this ModelStateDictionary state)
        => state.SelectMany(x => x.Value!.Errors).Select(x => ErrorResponse.CreateError(x.ErrorMessage)
            .WithDeveloperMessage(x.Exception?.Message)
            .WithStackTrace(x.Exception?.StackTrace)
            .WithException(x.Exception?.ToString())).ToList();
}
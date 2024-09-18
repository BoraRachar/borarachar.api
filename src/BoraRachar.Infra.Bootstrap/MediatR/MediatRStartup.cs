using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using MediatR;
using BoraRachar.Application.Bases;
using Microsoft.Extensions.DependencyInjection;

namespace BoraRachar.Infra.Bootstrap.MediatR;

[ExcludeFromCodeCoverage]
public static class MediatRStartup
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection services)
    {
        var assembly = Assembly.GetAssembly(typeof(FailRequestBehaviorWithResponseHandler<,>));
       
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailRequestBehaviorWithResponseHandler<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddMediatR(assembly!);

        return services;
    }
}
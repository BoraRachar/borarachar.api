using System.Reflection;
using BoraRachar.Domain.Service.Abstract.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace BoraRachar.Infra.Bootstrap.AutoMapper;

public static class AutoMapperStartup
{
    public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        => services.AddAutoMapper(Assembly.GetAssembly(typeof(BaseAutoMapper)));
}
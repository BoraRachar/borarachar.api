using System.Diagnostics.CodeAnalysis;
using BoraRachar.Domain.Service.Abstract.Interfaces.Categorias;
using BoraRachar.Domain.Service.Abstract.Interfaces.Email;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Domain.Service.Concretes.Categorias;
using BoraRachar.Domain.Service.Concretes.Email;
using BoraRachar.Domain.Service.Concretes.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BoraRachar.Infra.Bootstrap.Service;

[ExcludeFromCodeCoverage]
public static class ServiceStartup
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		//Usuarios
		services.AddTransient<IUserService, UserService>();
		services.AddScoped<IAcessManager, AccessManager>();
		services.AddScoped<IEmailService, EmailService>();
		
		// Categorias
		services.AddScoped<ICategoriaService, CategoriaService>();

		return services;
	}
}
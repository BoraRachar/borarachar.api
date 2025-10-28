using System.Diagnostics.CodeAnalysis;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using BoraRachar.Domain.Service.Abstract.Interfaces.Categorias;
using BoraRachar.Domain.Service.Abstract.Interfaces.Convites;
using BoraRachar.Domain.Service.Abstract.Interfaces.Email;
using BoraRachar.Domain.Service.Abstract.Interfaces.Groups;
using BoraRachar.Domain.Service.Abstract.Interfaces.Participantes;
using BoraRachar.Domain.Service.Abstract.Interfaces.ParticipantesGrupos;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Domain.Service.Concretes.Amizades;
using BoraRachar.Domain.Service.Concretes.Categorias;
using BoraRachar.Domain.Service.Concretes.Convites;
using BoraRachar.Domain.Service.Concretes.Email;
using BoraRachar.Domain.Service.Concretes.Groups;
using BoraRachar.Domain.Service.Concretes.NovoEmail;
using BoraRachar.Domain.Service.Concretes.Participantes;
using BoraRachar.Domain.Service.Concretes.ParticipantesGrupo;
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
		services.AddScoped<INovoEmailService, NovoEmailService>();
		
		// Categorias
		services.AddScoped<ICategoriaService, CategoriaService>();
		// Grupos
		services.AddScoped<IGroupService, GroupService>();
		// Participantes Grupo
		services.AddScoped<IParticipantesGrupoService, ParticipantesGrupoService>();
		// Amizades
		services.AddScoped<IAmizadeService, AmizadeService>();
		// Convites
		services.AddScoped<IConviteService, ConviteService>();
		// Participantes
		services.AddScoped<IParticipantesService, ParticipantesService>();

		return services;
	}
}
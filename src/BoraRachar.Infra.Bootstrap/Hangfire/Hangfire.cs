using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BoraRachar.Infra.Bootstrap.Hangfire;

[ExcludeFromCodeCoverage]
public static class Hangfire
{
	public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
	{
		// Add Hangfire services.
		services.AddHangfire(config => config
			.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
			.UseSimpleAssemblyNameTypeSerializer()
			.UseRecommendedSerializerSettings()
			.UseSqlServerStorage(configuration["ConnectionStrings:Connection"], new SqlServerStorageOptions
			{
				SchemaName = "dbo",
				CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
				SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
				QueuePollInterval = TimeSpan.Zero,
				UseRecommendedIsolationLevel = true,
				DisableGlobalLocks = true,
			}));

		// Add the processing server as IHostedService
		services.AddHangfireServer();

		return services;
	}
}

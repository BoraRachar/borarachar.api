using System.Text.Json.Serialization;
using Hangfire.Dashboard;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.Bootstrap.Version;
using BoraRachar.Infra.CrossCuting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace BoraRachar.Infra.Bootstrap.Configuration;

public static class AddConfiguration
{
	public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, params Type[] filters)
	{
		services.AddFluentValidationRulesToSwagger();
		services.AddControllers(options =>
		{
			if (filters?.Length > 0)
				foreach (var filter in filters)
					options.Filters.Add(filter);
		}).AddConfigureApiBehavior()
			.ConfigureApiBehaviorOptions(options =>
			{
				options.InvalidModelStateResponseFactory = context =>
				{
					var state = context.ModelState
						.Where(x => x.Value?.ValidationState == ModelValidationState.Invalid)
						.SelectMany(x => x.Value!.Errors)
						.Select(x => ErrorResponse.CreateError(x.ErrorMessage)
							.WithDeveloperMessage(x.Exception?.Message)
							.WithStackTrace(x.Exception?.StackTrace)
							.WithException(x.Exception?.ToString()));
					return new BadRequestObjectResult(ResponseDto<None>.Fail(state));
				};
			});

		return services;
	}

	public static IApplicationBuilder UseDefaultConfigure(this WebApplication app, IWebHostEnvironment env, string applicationName)
	{

		app.UseSwagger();
		var provider = app.Services.GetService<IApiVersionDescriptionProvider>();

		app.UseSwaggerUI(options =>
		{
			options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
			foreach (var description in provider!.ApiVersionDescriptions)
				options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
		});


		app.UseExceptionHandler("/error");
		app.UseHealthCheck();
		app.UseHttpsRedirection();
		app.UseRouting();
		app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

		return app;
	}

	public class DashboardNoAuthorizationFilter : IDashboardAuthorizationFilter
	{
		public bool Authorize(DashboardContext dashboardContext)
		{
			return true;
		}
	}

	private static IMvcBuilder AddConfigureApiBehavior(this IMvcBuilder builder)
		=>
			builder.AddJsonOptions(
				options => { options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; });
}
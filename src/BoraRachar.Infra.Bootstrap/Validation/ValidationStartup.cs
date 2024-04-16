using System.Globalization;
using FluentValidation.AspNetCore;
using BoraRachar.Application.Bases;
using Microsoft.Extensions.DependencyInjection;

namespace BoraRachar.Infra.Bootstrap.Validation;

public static class ValidationStartup
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidation(
            s =>
            {
                s.LocalizationEnabled = true;
                s.DisableDataAnnotationsValidation = true;
                s.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                s.RegisterValidatorsFromAssemblyContaining(typeof(RequestValidator<>));
            });
        return services;
    }
}
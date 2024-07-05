using BoraRachar.Application.Bases;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

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
                s.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR", true);
                s.RegisterValidatorsFromAssemblyContaining(typeof(RequestValidator<>));
            });
        return services;
    }
}
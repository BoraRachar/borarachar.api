using BoraRachar.Application.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;
using FluentValidation;

namespace BoraRachar.Application.GruposCases.AdicionarGrupos;

public class AdicionarGruposValidator : RequestValidator<AdicionarGrupoRequest>
{
    public AdicionarGruposValidator()
    {
        RuleFor(r => r.Descricao)
            .NotEmpty()
            .WithMessage("Por favor, informe a descricao");
    }
}
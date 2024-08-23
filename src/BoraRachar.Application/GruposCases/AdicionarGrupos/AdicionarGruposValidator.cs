using BoraRachar.Application.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupo.AdicionarGrupo;
using FluentValidation;

namespace BoraRachar.Application.GruposCases.AdicionarGrupos;

public class AdicionarGruposValidator : RequestValidator<AdicionarGrupoRequestDto>
{
    public AdicionarGruposValidator()
    {
        RuleFor(group => group.UserAdm)
            .NotEmpty()
            .WithMessage("O usuário administradoré obrigatório!");
    }
}
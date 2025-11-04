using BoraRachar.Domain.Entity.Despesas;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.Despesas;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Despesas;

public partial class DespesaService: BaseService, IDespesaService
{
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly IBaseRepository<Despesa> _repositoryDespesa;
    private readonly IBaseRepository<Grupos> _repositoryGrupos;
    private readonly IBaseRepository<Entity.Grupos.ParticipantesGrupo> _repositoryParticipantesGrupo;
    private readonly IBaseRepository<ParticipanteDepesa> _repositoryParticipanteDepesa;
    
    public DespesaService(ILogger<DespesaService> logger
        , IBaseRepository<ParticipanteDepesa> repositoryParticipanteDepesa
        , IBaseRepository<Despesa> repositoryDespesa
        , IBaseRepository<Grupos> repositoryGrupos
        , IBaseRepository<Entity.Grupos.ParticipantesGrupo> repositoryParticipantesGrupo
        , UserManager<User> userManager
        , IConfiguration config) : base(logger)
    {
        _config = config;
        _userManager = userManager;
        _repositoryDespesa = repositoryDespesa;
        _repositoryGrupos = repositoryGrupos;
        _repositoryParticipantesGrupo = repositoryParticipantesGrupo;
        _repositoryParticipanteDepesa = repositoryParticipanteDepesa;
    }
    
    private decimal CalcularValorParticipante(ParticipanteDepesa participanteDespesa
        , IEnumerable<ParticipanteDepesa> participantesDespesa
        , Despesa despesa)
    {
        if (participanteDespesa == null)
            throw new ArgumentNullException(nameof(participanteDespesa));

        if (participantesDespesa == null)
            throw new ArgumentNullException(nameof(participantesDespesa));

        if (despesa == null)
            throw new ArgumentNullException(nameof(despesa));

        decimal valor = 0;

        if (participanteDespesa.IsRecebedor)
        {
            // Recebedor recebe o valor total
            valor = despesa.ValorDespesa;
        }
        else if (participanteDespesa.IsPagador)
        {
            // Pagador divide igualmente entre os pagadores
            int totalPagadores = participantesDespesa.Count(p => p.IsPagador);
            if (totalPagadores == 0)
                throw new InvalidOperationException("Não há pagadores definidos para a despesa.");

            valor = despesa.ValorDespesa / totalPagadores;
        }

        return valor;
    }

}
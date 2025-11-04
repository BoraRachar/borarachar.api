using BoraRachar.Domain.Entity.Despesas;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.Atividades;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Atividades;

public partial class AtividadeService: BaseService, IAtividadeService
{
    private readonly IConfiguration _config;
    private readonly IBaseRepository<Entity.Grupos.ParticipantesGrupo> _repositoryParticipantesGrupo;
    private readonly IBaseRepository<Grupos> _repositoryGrupo;
    private readonly IBaseRepository<Despesa> _repositoryDespesa;
    private readonly IBaseRepository<ParticipanteDepesa> _repositoryParticipanteDepesa;
    
    public AtividadeService(ILogger<AtividadeService> logger
        , IBaseRepository<ParticipanteDepesa> repositoryParticipanteDepesa
        , IBaseRepository<Despesa> repositoryDespesa
        , IBaseRepository<Grupos> repositoryGrupo
        , IBaseRepository<Entity.Grupos.ParticipantesGrupo> repositoryParticipantesGrupo
        , IConfiguration config) : base(logger)
    {
        _config = config;
        _repositoryParticipantesGrupo = repositoryParticipantesGrupo;
        _repositoryGrupo = repositoryGrupo;
        _repositoryDespesa = repositoryDespesa;
        _repositoryParticipanteDepesa = repositoryParticipanteDepesa;
    }
}
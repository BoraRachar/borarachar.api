using BoraRachar.Domain.Entity.Amizades;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.Participantes;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Participantes;

public partial class ParticipantesService: BaseService, IParticipantesService
{
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly IBaseRepository<Grupos> _repositoryGrupos;
    private readonly IBaseRepository<Amizade> _repositoryAmizade;
    private readonly IBaseRepository<Entity.Grupos.ParticipantesGrupo> _repositoryParticipantesGrupo;
    
    public ParticipantesService(ILogger<ParticipantesService> logger
        , IBaseRepository<Entity.Grupos.ParticipantesGrupo> repositoryParticipantesGrupo
        , IBaseRepository<Grupos> repositoryGrupos
        , IBaseRepository<Amizade> repositoryAmizade
        , UserManager<User> userManager
        , IConfiguration config) : base(logger)
    {
        _config = config;
        _userManager = userManager;
        _repositoryGrupos = repositoryGrupos;
        _repositoryAmizade = repositoryAmizade;
        _repositoryParticipantesGrupo = repositoryParticipantesGrupo;
    }
}
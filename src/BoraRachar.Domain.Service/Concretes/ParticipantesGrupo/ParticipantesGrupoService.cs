using AutoMapper;
using BoraRachar.Domain.Entity.Amizades;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.ParticipantesGrupos;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.ParticipantesGrupo;

public partial class ParticipantesGrupoService: BaseService, IParticipantesGrupoService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IBaseRepository<Grupos> _repositoryGrupos;
    private readonly IBaseRepository<Amizade> _repositoryAmizade;
    private readonly IBaseRepository<Entity.Grupos.ParticipantesGrupo> _repositoryParticipantesGrupo;
    
    public ParticipantesGrupoService(
        IConfiguration config,
        IMapper mapper,
        UserManager<User> userManager,
        IBaseRepository<Amizade> repositoryAmizade, 
        IBaseRepository<Grupos> repositoryGrupos,
        IBaseRepository<Entity.Grupos.ParticipantesGrupo> repositoryParticipantesGrupo,
        ILogger<ParticipantesGrupoService> logger): base(logger)
    {
        _config = config;
        _mapper = mapper;
        _userManager = userManager;
        _repositoryGrupos = repositoryGrupos;
        _repositoryParticipantesGrupo = repositoryParticipantesGrupo;
        _repositoryAmizade = repositoryAmizade;
    }
}
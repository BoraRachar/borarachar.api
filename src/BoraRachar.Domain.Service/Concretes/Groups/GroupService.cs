using AutoMapper;
using BoraRachar.Domain.Entity.Categorias;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.Groups;
using BoraRachar.Domain.Service.Abstract.Interfaces.ParticipantesGrupos;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService: BaseService, IGroupService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IBaseRepository<Grupos> _repository;
    private readonly IBaseRepository<Categoria> _repositoryCategoria;
    private readonly IParticipantesGrupoService _participantesGrupoService;
    
    public GroupService(
        ILogger<GroupService> logger,
        IConfiguration config,
        IMapper mapper,
        UserManager<User> userManager,
        IParticipantesGrupoService participantesGrupoService,
        IBaseRepository<Categoria> repositoryCategoria,
        IBaseRepository<Grupos> repository
        ) : base(logger)
    {
        _config = config;
        _mapper = mapper;
        _userManager = userManager;
        _participantesGrupoService = participantesGrupoService;
        _repository = repository;
        _repositoryCategoria = repositoryCategoria;
    }
}
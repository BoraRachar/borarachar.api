using AutoMapper;
using BoraRachar.Domain.Entity.Amizades;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using BoraRachar.Domain.Service.Abstract.Interfaces.Email;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Amizades;

public partial class AmizadeService: BaseService, IAmizadeService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Amizade> _repository;
    private readonly IBaseRepository<Convite> _repositoryConvite;
    private readonly IBaseRepository<Grupos> _repositoryGrupo;
    private readonly IBaseRepository<Entity.Grupos.ParticipantesGrupo> _repositoryParticipantesGrupo;
    private readonly IEmailService _emailService;
    private readonly UserManager<User> _userManager;
    
    public AmizadeService(
        ILogger<AmizadeService> logger,
        IMapper mapper,
        IConfiguration config,
        IEmailService emailService,
        IBaseRepository<Amizade> repository,
        IBaseRepository<Convite> repositoryConvite,
        IBaseRepository<Entity.Grupos.ParticipantesGrupo> repositoryParticipantesGrupo,
        IBaseRepository<Grupos> repositoryGrupo,
        UserManager<User> userManager
        ) : base(logger)
    {
        _config = config;
        _mapper = mapper;
        _repository = repository;
        _emailService = emailService;
        _userManager = userManager;
        _repositoryConvite = repositoryConvite;
        _repositoryGrupo = repositoryGrupo;
        _repositoryParticipantesGrupo = repositoryParticipantesGrupo;
    }

    private async Task<bool> VerifyAmizade(string userId, string amigoId, CancellationToken cancellationToken)
    {
        bool hasAmizade = false;

        var amizade = await _repository.GetByAsync(a => (a.UserId == userId && a.AmigoId == amigoId) || (a.AmigoId == userId && a.UserId == amigoId), cancellationToken);

        return amizade.Count() > 0;
    }
}
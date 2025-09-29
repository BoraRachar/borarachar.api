using BoraRachar.Domain.Entity.Despesas;
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
    private readonly IBaseRepository<ParticipanteDepesa> _repositoryParticipanteDepesa;
    
    public DespesaService(ILogger<DespesaService> logger
        , IBaseRepository<ParticipanteDepesa> repositoryParticipanteDepesa
        , IBaseRepository<Despesa> repositoryDespesa
        , UserManager<User> userManager
        , IConfiguration config) : base(logger)
    {
        _config = config;
        _userManager = userManager;
        _repositoryDespesa = repositoryDespesa;
        _repositoryParticipanteDepesa = repositoryParticipanteDepesa;
    }
}
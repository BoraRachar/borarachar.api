using AutoMapper;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.Groups;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService: BaseService, IGroupService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Grupos> _repository;
    
    public GroupService(
        ILogger<GroupService> logger,
        IConfiguration config,
        IMapper mapper,
        IBaseRepository<Grupos> repository
        ) : base(logger)
    {
        _config = config;
        _mapper = mapper;
        _repository = repository;
    }
    
    
    
}
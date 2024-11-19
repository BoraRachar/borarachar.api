using AutoMapper;
using BoraRachar.Domain.Entity.Amizades;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.Convites;
using BoraRachar.Domain.Service.Abstract.Interfaces.Email;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Convites;

public partial class ConviteService: BaseService, IConviteService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Convite> _repository;
    private readonly IEmailService _emailService;


    public ConviteService(
        IMapper mapper,
        IBaseRepository<Convite> repository,
        IConfiguration config,
        IEmailService emailService,
        ILogger<ConviteService> logger) : base(logger)
    {
        _repository = repository;
        _config = config;
        _mapper = mapper;
        _emailService = emailService;
    }
}
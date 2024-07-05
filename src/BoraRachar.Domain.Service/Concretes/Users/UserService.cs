using AutoMapper;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Interfaces.Email;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using BoraRachar.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService : BaseService, IUserService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IBaseRepository<UserEntity> _repository;
    private readonly IBaseRepository<VerifyUser> _repositoryVerifyUser;
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;

    public UserService(ILogger<UserService> logger,
        IMapper mapper,
        IBaseRepository<UserEntity> repository,
        IBaseRepository<VerifyUser> repositoryVerifyUser,
        UserManager<User> userManager,
        IConfiguration config,
        IEmailService emailService) : base(logger)
    {
        _mapper = mapper;
        _repository = repository;
        _userManager = userManager;
        _config = config;
        _emailService = emailService;
        _repositoryVerifyUser = repositoryVerifyUser;
    }


    public static int GenerateCode()
    {
        Random rand = new Random();

        int code = rand.Next(100000, 999999);

        return code;
    }
}
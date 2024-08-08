using AutoMapper;
using BoraRachar.Domain.Entity.Categorias;
using BoraRachar.Domain.Repository.Orm.Abstract.Repositories;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;
using BoraRachar.Domain.Service.Abstract.Interfaces.Categorias;
using BoraRachar.Domain.Service.Concretes.Bases;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Categorias;

public partial class CategoriaService: BaseService, ICategoriaService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Categoria> _repository;
    
    public CategoriaService(
        ILogger<CategoriaService> logger,
        IMapper mapper,
        IBaseRepository<Categoria> repository,
        IConfiguration config
    ) : base(logger)
    {
        _config = config;
        _mapper = mapper;
        _repository = repository;
    }
}
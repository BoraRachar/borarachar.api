using System.Net;
using BoraRachar.Domain.Entity.Categorias;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Categorias;

public partial class CategoriaService
{
    public async Task<ResponseDto<None>> AddCategoriaAsync(AddCategoriaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddCategoriaAsync));
        try
        {
            var existCategoria = await _repository.GetByAsync(c => c.Descricao == request.Descricao, cancellationToken);

            if (existCategoria.Count() > 0)
            {
                return ResponseDto.Fail("Categoria já cadastrada", HttpStatusCode.BadRequest);
            }

            var categoria = new Categoria()
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                Descricao = request.Descricao,
                Ativo = true,
                DataCadastro = DateTime.Now
            };
            
            await _repository.InsertAsync(categoria, cancellationToken);
            bool succeeded = await _repository.SaveChangeAsync(cancellationToken);

            if (!succeeded)
            {
                return ResponseDto.Fail($"Falha ao cadastrar categoria:", HttpStatusCode.BadRequest);
            }
            
            return ResponseDto.Sucess("Cadastrado com sucesso.", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddCategoriaAsync));
        }
    }
}
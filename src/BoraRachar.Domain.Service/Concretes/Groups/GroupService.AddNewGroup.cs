using System.Net;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.AddGrupo;
using BoraRachar.Domain.Service.Concretes.Helpers;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService 
{
    public async Task<ResponseDto<None>> CreateNewGroup(AddGrupoRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(CreateNewGroup));
        try
        {
            bool isValidImage = false;

            if (!string.IsNullOrEmpty(request.ImgGrupo))
            {
                isValidImage = ServiceHelpers.IsBase64Image(request.ImgGrupo);
                if (isValidImage.Equals(false))
                {
                    return ResponseDto.Fail("Imagem invalida.", HttpStatusCode.BadRequest);
                }
            }
            
            var novoGrupo = new Grupos(
                nome: request.Nome,
                idCategoria: request.IdCategoria,
                descricao: request.Descricao,
                tipoDivisao: request.TipoDivisao,
                outrasCategorias: request.OutrasCategorias,
                imgGrupo: request.ImgGrupo!
            );

            await _repository.InsertAsync(novoGrupo, cancellation);
            await _repository.SaveChangeAsync(cancellation);

            if (request?.Participantes?.Count > 0)
            {
                foreach (var participante in request.Participantes)
                {
                    
                }
            }
            
            return ResponseDto.Sucess("Cadastrado com sucesso.", HttpStatusCode.Created);
                  
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(CreateNewGroup));
        }        
    }
}

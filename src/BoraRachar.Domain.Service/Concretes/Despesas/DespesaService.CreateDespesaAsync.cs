using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Despesas;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.AddDespesa;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Despesas;

public partial class DespesaService
{
    public async Task<ResponseDto<None>> CreateDespesaAsync(AddDespesaRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(CreateDespesaAsync));
     
        var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return ResponseDto.Fail("Usuario invalido.", HttpStatusCode.BadRequest);
        }

        if (request.Pagadores.Count <= 0)
        {
            return ResponseDto.Fail("Voce deve listar quem vai pagar pela despesa.", HttpStatusCode.BadRequest);
        }
        
        if (request.Recebedores.Count <= 0)
        {
            return ResponseDto.Fail("Voce deve listar quem vai receber pela despesa.", HttpStatusCode.BadRequest);
        }
        
        var despesa = new Despesa(request.Nome, request.Descricao, request.ValorDespesa, request.DataRealizacao, request.IdGrupo, userId);

        var pagadores = new List<ParticipanteDepesa>();
        var recebores = new List<ParticipanteDepesa>();
        if (request.Pagadores.Count > 0)
        {
            foreach (var pagador in request.Pagadores)
            {
                var pag = new ParticipanteDepesa(despesa.Id, request.IdGrupo, pagador, true);
                pagadores.Add(pag);
            }
        }
        
        if (request.Recebedores.Count > 0)
        {
            foreach (var recebedor in request.Recebedores)
            {
                var rec = new ParticipanteDepesa(despesa.Id, request.IdGrupo, recebedor, false, true);
                recebores.Add(rec);
            }
        }

        try
        {
            await _repositoryDespesa.InsertAsync(despesa, cancellation);
            await _repositoryDespesa.SaveChangeAsync(cancellation);

            await _repositoryParticipanteDepesa.BulkInsertAsync(pagadores, cancellation);
            await _repositoryParticipanteDepesa.BulkInsertAsync(recebores, cancellation);
            await _repositoryParticipanteDepesa.SaveChangeAsync(cancellation);
            
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(CreateDespesaAsync));
        }
    }
}
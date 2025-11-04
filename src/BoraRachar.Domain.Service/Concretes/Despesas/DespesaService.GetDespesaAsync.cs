using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Despesas;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.AddDespesa;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.GetDespesa;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Despesas;

public partial class DespesaService
{
    public async Task<ResponseDto<GetDespesaResponseDto>> GetDespesaAsync(GetDespesaRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(GetDespesaAsync));
     
        var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return ResponseDto<GetDespesaResponseDto>.Fail("Usuario invalido.", HttpStatusCode.BadRequest);
        }

        try
        {
            
            var response = new GetDespesaResponseDto();
            var despesa = await _repositoryDespesa.GetByIdAsync(request.DespesaId, cancellation);
            var participantesDespesa = await _repositoryParticipanteDepesa.GetByAsync(p => p.IdDespesa == despesa.Id, cancellation);
            var grupo = await _repositoryGrupos.GetByIdAsync(participantesDespesa.First().IdGrupo, cancellation);
            if (despesa.UserId == userId)
            {
                response.NomeDespesa = despesa.Nome;
                response.NomeGrupo = grupo.Nome;
                response.DescricaoDespesa = despesa.Descricao;
                response.CriadorDespesa = user.UserName;
                response.DataRealizacao = despesa.DataRealizacao;
                response.ValorTotal = despesa.ValorDespesa;

                var participantes = new List<ParticipantesResponseDto>();
                foreach (var participanteDepesa in participantesDespesa)
                {
                    decimal valorDespesa = 0;
                    if (participanteDepesa.IsPagador)
                    {
                        valorDespesa = despesa.ValorDespesa;
                    }

                    if (participanteDepesa.IsRecebedor)
                    {
                        int divisor = participantesDespesa.Where(p => p.IsRecebedor.Equals(true)).Count();  
                        valorDespesa = (despesa.ValorDespesa / divisor);
                    }
                    var participantegrupo = await _repositoryParticipantesGrupo.GetByIdAsync(participanteDepesa.IdParticipantesGrupo, cancellation);
                    
                    var usuario = await _userManager.FindByIdAsync(participantegrupo.UserId);
                    var partic = new ParticipantesResponseDto
                    {
                        Nome = usuario.Nome,
                        Valor = valorDespesa,
                        IsPagador = participanteDepesa.IsPagador,
                        IsRecebedor = participanteDepesa.IsRecebedor
                    };
                    participantes.Add(partic);
                }

                response.Participantes = participantes;
            }
            
            return ResponseDto<GetDespesaResponseDto>.Sucess(response);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<GetDespesaResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(GetDespesaAsync));
        }
    }
}
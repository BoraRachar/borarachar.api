using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Despesas;
using BoraRachar.Domain.Service.Abstract.Dtos.Atividades.ListaAtividades;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Atividades;

public partial class AtividadeService
{
    public async Task<ResponseDto<IEnumerable<ListaAtividadesResponseDto>>> ListAtividadesAsync(ListaAtividadesRequestDto request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListAtividadesAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

            var participantes = await _repositoryParticipantesGrupo.GetByAsync(p => p.UserId == userId, cancellationToken);
            var despesas = new List<Despesa>();

            foreach (var participante in participantes)
            {
                var despesasGrupo = await _repositoryDespesa.GetByAsync(d => d.GrupoId == participante.GrupoId, cancellationToken);
                despesas.AddRange(despesasGrupo);
            }
            
            var listAtividades = new List<ListaAtividadesResponseDto>();

            foreach (var despesa in despesas)
            {
                var grupo = await _repositoryGrupo.GetByIdAsync(despesa.GrupoId, cancellationToken);
                var participantesGrupo =  participantes.Where(p => p.GrupoId == despesa.GrupoId && p.UserId == userId).FirstOrDefault();
                var participanteDespesa = await _repositoryParticipanteDepesa.GetByOneAsync(p => p.IdGrupo == despesa.GrupoId 
                                                                                                 && p.IdDespesa == despesa.Id
                                                                                              && p.IdParticipantesGrupo == participantesGrupo.Id, cancellationToken);
                var participantesDespesa =  await _repositoryParticipanteDepesa.GetByAsync(p => p.IdGrupo == despesa.GrupoId 
                                                                                                && p.IdDespesa == despesa.Id, cancellationToken);
                
                decimal valor = 0;
                if (participanteDespesa.IsPagador)
                {
                    //TODO regra do grupo
                    int divisor = participantesDespesa.Where(p => p.IsPagador.Equals(true)).Count();  
                    valor = (despesa.ValorDespesa / divisor);
                }

                if (participanteDespesa.IsRecebedor)
                {
                    valor = despesa.ValorDespesa;
                }
                
                var atividade = new ListaAtividadesResponseDto
                {
                    Data = despesa.DataRealizacao,
                    Atividade = new Atividade
                    {
                        IdDespesa = despesa.Id,
                        DescDespesa = despesa.Nome,
                        IdGrupo = despesa.GrupoId,
                        DescGrupo = grupo.Nome,
                        Valor = valor,
                        IsPagador = participanteDespesa.IsPagador,
                        IsRecebedor = participanteDespesa.IsRecebedor
                    }
                };
                
                listAtividades.Add(atividade);
            }

            if (listAtividades.Any())
            {
                return ResponseDto<IEnumerable<ListaAtividadesResponseDto>>.Sucess(listAtividades);
            }
            else
            {
                return ResponseDto<IEnumerable<ListaAtividadesResponseDto>>.Fail(HttpStatusCode.NotFound);
            }
            
           
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListaAtividadesResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListAtividadesAsync));
        }
    }
}
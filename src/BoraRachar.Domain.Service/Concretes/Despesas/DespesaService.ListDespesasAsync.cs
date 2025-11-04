using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Despesas;
using BoraRachar.Domain.Entity.Enum;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.AddDespesa;
using BoraRachar.Domain.Service.Abstract.Dtos.Despesas.ListDespesas;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Despesas;

public partial class DespesaService
{
    public async  Task<ResponseDto<IEnumerable<ListDespesasResponseDto>>> ListDespesasAsync(ListDespesasRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListDespesasAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);
            
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return ResponseDto<IEnumerable<ListDespesasResponseDto>>.Fail("Usuario invalido.", HttpStatusCode.BadRequest);
            }

            var listaDespesas = new List<ListDespesasResponseDto>();

            var participantesGrupo = await _repositoryParticipantesGrupo.GetByAsync(p => p.UserId == userId, cancellation);

            foreach (var participante in participantesGrupo)
            {
                var grupo = await _repositoryGrupos.GetByOneAsync(g => g.Id == participante.GrupoId, cancellation);

                if (grupo != null)
                {
                    var tipoDivisao = Helpers.ServiceHelpers.GetTipoDivisao(grupo.TipoDivisao);

                    var despesas = await _repositoryDespesa.GetByAsync(d => d.GrupoId == participante.GrupoId, cancellation);

                    if (despesas.Any())
                    {
                        foreach (var despesa in despesas)
                        {
                            var participantesDespesas = await _repositoryParticipanteDepesa.GetByAsync(p => p.IdDespesa == despesa.Id, cancellation);

                            int pagadores = participantesDespesas.Where(p => p.IsPagador.Equals(true)).Count();

                            if (participantesDespesas.Any())
                            {
                                var participanteDesp = participantesDespesas.FirstOrDefault(p => p.IdParticipantesGrupo == participante.Id);

                                decimal valor = 0;
                                if (tipoDivisao.Equals(TipoDivisao.Cotas) || tipoDivisao.Equals(TipoDivisao.ValorExato) || tipoDivisao.Equals(TipoDivisao.ValorExato))
                                {
                                    valor = Math.Round(despesa.ValorDespesa / participantesDespesas.Count(), 2);
                                }
                                else
                                {
                                    valor = Math.Round(despesa.ValorDespesa / pagadores, 2);
                                }
                               
                                var resp = new ListDespesasResponseDto
                                {
                                    IdDespesa = despesa.Id,
                                    NomeDespesa = despesa.Nome,
                                    DescricaoGrupo = grupo.Nome,
                                    IdParticipante = participanteDesp.IdParticipantesGrupo,
                                    ValorDespesa = participanteDesp.IsRecebedor ? valor * -1 : valor,
                                    Pagador = participanteDesp.IsRecebedor,
                                    Devedor = participanteDesp.IsPagador
                                };

                                listaDespesas.Add(resp);
                            }
                        }
                    }
                }
            }
            return ResponseDto<IEnumerable<ListDespesasResponseDto>>.Sucess(listaDespesas);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListDespesasResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListDespesasAsync));
        }
    }
}
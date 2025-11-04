using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Despesas.GetDespesa;

public class GetDespesaResponseDto:ResponseDto
{
    public string NomeDespesa { get; set; }
    public string NomeGrupo { get; set; }
    public string DescricaoDespesa { get; set; }
    public string CriadorDespesa { get; set; }
    public DateTime DataRealizacao { get; set; }
    public decimal ValorTotal { get; set; }
    public List<ParticipantesResponseDto> Participantes { get; set; }
}

public class ParticipantesResponseDto
{
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public bool IsPagador { get; set; }
    public bool IsRecebedor { get; set; }
}
namespace BoraRachar.Domain.Service.Abstract.Dtos.Despesas.ListDespesas;

public class ListDespesasResponseDto
{
    public string IdDespesa { get; set; }
    public string NomeDespesa { get; set; }
    public string IdParticipante { get; set; }
    public string DescricaoGrupo { get; set; }
    public decimal ValorDespesa { get; set; }
    public bool Pagador { get; set; }
    public bool Devedor { get; set; }
}
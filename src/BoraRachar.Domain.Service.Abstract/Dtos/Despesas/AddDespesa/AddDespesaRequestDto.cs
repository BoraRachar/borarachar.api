namespace BoraRachar.Domain.Service.Abstract.Dtos.Despesas.AddDespesa;

public class AddDespesaRequestDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal ValorDespesa { get; set; }
    public DateTime DataRealizacao { get; set; }
    public string IdGrupo { get; set; }
    public string UserCod { get; set; }
    public List<string> Pagadores { get; set; }
    public List<string> Recebedores { get; set; }
}
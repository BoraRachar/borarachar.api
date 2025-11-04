namespace BoraRachar.Domain.Service.Abstract.Dtos.Atividades.ListaAtividades;

public class ListaAtividadesResponseDto
{
    public DateTime Data { get; set; }
    public Atividade Atividade { get; set; }
}

public class Atividade
{
    public string IdDespesa { get; set; }
    public string DescDespesa { get; set; }
    public string IdGrupo { get; set; }
    public string DescGrupo { get; set; }
    public decimal Valor { get; set; }
    public bool IsPagador { get; set; }
    public bool IsRecebedor { get; set; }
}
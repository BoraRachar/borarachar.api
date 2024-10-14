namespace BoraRachar.Domain.Service.Abstract.Dtos.Grupos.FindOneGrupo;

public class FindOneGrupoResponseDto
{
    public string GrupoId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public bool IsAdm { get; set; }
}
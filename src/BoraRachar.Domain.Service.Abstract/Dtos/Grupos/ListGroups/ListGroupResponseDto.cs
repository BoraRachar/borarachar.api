namespace BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListGroups;

public class ListGroupResponseDto
{
    public string Nome { get; set; }        
    public string GrupoId { get; set; }
    public string Descricao { get; set; }
    public string ImgGrupo { get; set; }
    public int TotalParticipantes { get; set; }
}
namespace BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListGroups;

public class ListGroupResponseDto
{
    public string GrupoId { get; set; }
    public string Descricao { get; set; }
    public string Img { get; set; }
    public int Participantes { get; set; }
}
namespace BoraRachar.Domain.Service.Abstract.Dtos.Categorias.ListCategorias;

public class ListCategoriasResponseDto
{
    public string IdCategoria { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using BoraRachar.Domain.Entity.Bases;

namespace BoraRachar.Domain.Entity.Despesas;

public class Despesa: BaseEntity
{
    public Despesa()
    {
        
    }

    public Despesa(string nome, string descricao, decimal valor, DateTime dataRealizacao, string grupoId, string userId)
    {
        Id = Guid.NewGuid().ToString().ToLower();
        Nome = nome;
        Descricao = descricao;
        DataRealizacao = dataRealizacao;
        ValorDespesa = valor;
        DataCadastro = DateTime.UtcNow;
        GrupoId = grupoId;
        UserId = userId;
    }
    
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataRealizacao { get; set; }
    public DateTime DataCadastro { get; set; }
    public decimal ValorDespesa { get; set; }
    [ForeignKey("Grupos")]  
    public string GrupoId { get; set; }
    [ForeignKey("Users")]  
    public string UserId { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}
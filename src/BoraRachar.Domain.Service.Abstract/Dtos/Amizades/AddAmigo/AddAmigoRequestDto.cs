using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Amizades.AddAmigo;

public class AddAmigoRequestDto: RequestDto
{
    public string UserCod { get; set; }
    public string AmigoId { get; set; }
}
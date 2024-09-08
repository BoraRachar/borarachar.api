using System.Net;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;
using BoraRachar.Domain.Service.Concretes.Helpers;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService 
{
    public async Task<ResponseDto<None>> CreateNewGroup(AddCategoriaRequestDto request, CancellationToken cancellation)
    {
        var novoGrupo = new Grupos(
            idCategoria: request.IdCategoria,
            descricao: request.Descricao,
            tipoDivisao: ServiceHelpers.GetEnumValue(request.TipoDivisao),
            outrasCategorias: request.OutrasCategorias
        );

        await _repository.InsertAsync(novoGrupo, cancellation);

        return ResponseDto.Sucess("Grupo cadastrado!", HttpStatusCode.Created);
    }
}

using System.Net;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupo.AdicionarGrupo;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService 
{
    public async Task<ResponseDto<None>> CreateNewGroup(AdicionarGrupoRequestDto grupos, CancellationToken cancellation)
    {
        var novoGrupo = new Grupos(
            idCategoria: grupos.IdCategoria,
            descricao: grupos.Descricao,
            tipoDivisao: grupos.TipoDivisao,
            linkConvite: grupos.LinkConvite,
            userAdm: grupos.UserAdm,
            outrasCategorias: grupos.OutrasCategorias
        );

        await _repository.InsertAsync(novoGrupo, cancellation);

        return ResponseDto.Sucess("Grupo cadastrado!", HttpStatusCode.Created);
    }
}

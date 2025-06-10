using Microsoft.EntityFrameworkCore;

namespace BoraRachar.Domain.Service.Concretes.ParticipantesGrupo;


public partial class ParticipantesGrupoService
{
    public async Task<int> CountParticipantesGrupoAsync(string grupoId, CancellationToken cancellation)
    {
        var result =  await _repositoryParticipantesGrupo.Query.Where(g => g.GrupoId == grupoId).Select(g => g.UserId).CountAsync();
        return result;
    }
}
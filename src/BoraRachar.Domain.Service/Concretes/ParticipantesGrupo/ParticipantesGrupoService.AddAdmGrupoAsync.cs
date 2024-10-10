namespace BoraRachar.Domain.Service.Concretes.ParticipantesGrupo;

public partial class ParticipantesGrupoService
{
    public async Task<bool> AddParticipanteGrupoAdmAsync(string userId, string grupoId, CancellationToken cancellation)
    {
        var admGrupo = new Entity.Grupos.ParticipantesGrupo
        {
            Id = Guid.NewGuid().ToString().ToLower(),
            GrupoId = grupoId,
            UserId = userId,
            IsAdm = true,
            DataCadastro = DateTime.Now.AddHours(-3),
        };

        await _repositoryParticipantesGrupo.InsertAsync(admGrupo, cancellation);
        var result =  await _repositoryParticipantesGrupo.SaveChangeAsync(cancellation);

        return result;
    }
}
using HackathonFiap.Entities;

namespace HackathonFiap.Repository.Interfaces
{
    public interface IMedicoRepository
    {
        IEnumerable<Medico>? Get(int? especialidadeId, string? nome, string? cidade);
    }
}

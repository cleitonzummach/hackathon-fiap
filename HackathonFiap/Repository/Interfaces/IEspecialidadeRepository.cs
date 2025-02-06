using HackathonFiap.Entities;

namespace HackathonFiap.Repository.Interfaces
{
    public interface IEspecialidadeRepository
    {
        IEnumerable<Especialidade>? GetAll();
    }
}

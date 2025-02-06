using HackathonFiap.Context;
using HackathonFiap.Entities;
using HackathonFiap.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HackathonFiap.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ContextDB _context;

        public EspecialidadeRepository(ContextDB context) => _context = context;

        public IEnumerable<Especialidade> GetAll()
        {
            return _context.Especialidade.AsEnumerable();
        }
    }
}

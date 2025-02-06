using HackathonFiap.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackathonFiap.Context
{
    public class ContextDB : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
    }
}

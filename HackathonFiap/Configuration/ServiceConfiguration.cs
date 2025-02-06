using HackathonFiap.Context;
using HackathonFiap.Entities;
using HackathonFiap.Repository;
using HackathonFiap.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HackathonFiap.Configuration
{
    public static class ServiceConfiguration
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDB>(options => options.UseNpgsql(configuration.GetConnectionString("ContextDB")));

            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
        }
    }
}

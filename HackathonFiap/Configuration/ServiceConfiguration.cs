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
            var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
            var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
            var db = Environment.GetEnvironmentVariable("POSTGRES_DB");
            var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            var connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={password}";

            services.AddDbContext<ContextDB>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
        }
    }
}

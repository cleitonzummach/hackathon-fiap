using HackathonFiap.Context;
using HackathonFiap.Entities;
using HackathonFiap.Repository;
using HackathonFiap.Repository.Interfaces;
using HackathonFiap.Services;
using HackathonFiap.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("JwtKey"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
        }
    }
}

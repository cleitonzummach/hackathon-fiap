using HackathonFiap.Entities;
using HackathonFiap.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HackathonFiap.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(Medico medico)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var chaveCriptografia = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtKey"));

            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, medico.MedicoId.ToString()),
                    new Claim(ClaimTypes.Email, medico.Email)
                }),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCriptografia), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);
            
            return tokenHandler.WriteToken(token);
        }
    }
}

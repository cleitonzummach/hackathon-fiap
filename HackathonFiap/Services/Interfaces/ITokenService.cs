using HackathonFiap.Entities;

namespace HackathonFiap.Services.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Medico medico);
    }
}

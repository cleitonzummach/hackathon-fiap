using HackathonFiap.Entities;

namespace HackathonFiap.Dto
{
    public class MedicoDto
    {
        public int MedicoId { get; set; }
        public string Especialidade { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CRM { get; set; }

        public MedicoDto(Medico medico) 
        {
            MedicoId = medico.MedicoId;
            Especialidade = medico.Especialidade.Nome;
            Email = medico.Email;
            Cidade = medico.Cidade;
            Estado = medico.Estado;
            CRM = medico.CRM;
        }
    }
}

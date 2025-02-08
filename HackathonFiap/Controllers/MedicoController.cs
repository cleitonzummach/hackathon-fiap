using HackathonFiap.Repository;
using HackathonFiap.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackathonFiap.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MedicoController : Controller
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpGet]
        public IActionResult GetMedicos(int? especialidadeId, string? nome, string? cidade)
        {
            var medicos = _medicoRepository.Get(especialidadeId, nome, cidade);

            return Ok(medicos);
        }

        [HttpPost("CadastrarHorario")]
        public async Task<IActionResult> CadastrarHorario(DateTime data)
        {
            //http://localhost:5131/api/HorarioDisponivel

            var values = new Dictionary<string, string>
            {
                { "MedicoId", "1" },
                { "Data", data.Date.ToString("dd/MM/yyyy") },
                { "Hora", data.Date.ToString("HH:mm") },
                { "Disponivel", "true" }
            };

            var content = new FormUrlEncodedContent(values);

            HttpClient client = new HttpClient();
            var response = await client.PostAsync("http://localhost:5131/api/HorarioDisponivel", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return Ok();
        }
    }
}

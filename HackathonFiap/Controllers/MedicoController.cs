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
    }
}

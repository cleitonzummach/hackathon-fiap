using HackathonFiap.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackathonFiap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspecialidadeController : Controller
    {
        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        [HttpGet("consultar")]
        public IActionResult GetAll()
        {
            var especialidades = _especialidadeRepository.GetAll();

            return Ok(especialidades);
        }
    }
}

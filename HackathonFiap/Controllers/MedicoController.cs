using HackathonFiap.Dto;
using HackathonFiap.Entities;
using HackathonFiap.Repository;
using HackathonFiap.Repository.Interfaces;
using HackathonFiap.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackathonFiap.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly ITokenService _tokenService;

        public MedicoController(IMedicoRepository medicoRepository, ITokenService tokenService)
        {
            _medicoRepository = medicoRepository;
            _tokenService = tokenService;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar(string crm, string senha)
        {
            var medico = await _medicoRepository.Autenticar(crm, senha);

            if (medico != null)
            {
                var token = _tokenService.GerarToken(medico);

                if (!string.IsNullOrEmpty(token))
                    return Ok(token);
            }

            return Unauthorized();
        }

        [HttpGet("buscar")]
        [Authorize]
        public IActionResult GetMedicos(int? especialidadeId, string? nome, string? cidade)
        {
            var medicos = _medicoRepository.Get(especialidadeId, nome, cidade);

            if (medicos.Any())
                return Ok(medicos.Select(m => new MedicoDto(m)));

            return NoContent();
        }
    }
}

using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Zaion.Auth.Services;
using Zaion.Auth.Data.Dtos.Usuario;
using Zaion.Auth.Data.Requests;

namespace Zaion.Auth.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService) {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto) {
            Result resultado = _cadastroService.CadastraUsuario(createDto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }

        [HttpGet("/AtivarConta")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request) {
            Result resultado = _cadastroService.AtivaContaUsuario(request);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }
    }
}

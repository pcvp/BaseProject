using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Zaion.Auth.Data.Requests;
using Zaion.Auth.Services;

namespace Zaion.Auth.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase {
        private LoginService _loginService;

        public LoginController(LoginService loginService) {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Logar(LoginRequest request) {
            Result resultado = _loginService.Logar(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }

        [HttpPost("/resetarSenhaUsuario")]
        public IActionResult ResetaSenhaUsuario(ResetarSenhaUsuarioRequest request) {
            Result resultado = _loginService.ResetarSenhaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }
    }
}

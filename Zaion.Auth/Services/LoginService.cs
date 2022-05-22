using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

using Zaion.Auth.Models;
using Zaion.Auth.Data.Requests;

namespace Zaion.Auth.Services {
    public class LoginService {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager,
            TokenService tokenService) {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result Logar(LoginRequest request) {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded) {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.Username.ToUpper());

                var userRole = _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault();

                Token token = _tokenService.CreateToken(identityUser, userRole);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result ResetarSenhaUsuario(ResetarSenhaUsuarioRequest request) {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);

            IdentityResult resultadoIdentity = _signInManager
                .UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;
            if (resultadoIdentity.Succeeded) return Result.Ok()
                    .WithSuccess("Senha redefinida com sucesso!");
            return Result.Fail("Houve um erro na opera��o");
        }

        public Result SolicitarAlteracaoDeSenha(SolicitaResetRequest request) {
            IdentityUser<int> identityUser = RecuperaUsuarioPorEmail(request.Email);

            if (identityUser != null) {
                string codigoDeRecuperacao = _signInManager
                    .UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefini��o");
        }

        private IdentityUser<int> RecuperaUsuarioPorEmail(string email) {
            return _signInManager
                            .UserManager
                            .Users
                            .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}

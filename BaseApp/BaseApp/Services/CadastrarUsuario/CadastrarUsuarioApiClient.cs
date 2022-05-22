using BaseApp.Config;
using DTOs.RecuperacaoDeSenha;
using DTOs.Token;
using DTOs.Usuarios;
using BaseApp.Services.ApiClient.Base;
using CSharpFunctionalExtensions;
using System;
using System.Threading.Tasks;

namespace BaseApp.Services.ApiClient.RecuperarSenha {

    public class CadastrarUsuarioApiClient : BaseApiClient {

        public CadastrarUsuarioApiClient() : base(Configuracoes.BaseAddress) {
        }

        protected override string ResourceName => "/CadastroUsuario";

        public Task<Maybe<AuthResultDTO>> CadastroUsuario(UsuarioDetalhesDTO usuario) {
            return RequestPost<AuthResultDTO>(usuario);
        }

    }
}
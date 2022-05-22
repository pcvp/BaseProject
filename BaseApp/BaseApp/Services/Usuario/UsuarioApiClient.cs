using BaseApp.Config;
using DTOs.Usuarios;
using BaseApp.Services.ApiClient.Base;
using CSharpFunctionalExtensions;
using System;
using System.Threading.Tasks;

namespace BaseApp.Services.ApiClient.Usuario {

    public class UsuarioApiClient : BaseApiClient {

        public UsuarioApiClient() : base(Configuracoes.BaseAddress) {
        }

        protected override string ResourceName => "usuarios";

        public Task<Maybe<string>> ObterPermissoes() {
            throw new NotImplementedException();
        }
        public Task<Maybe<UsuarioDetalhesComPerfilDTO>> ObterUsuarioLogado() {
            return RequestGet<UsuarioDetalhesComPerfilDTO>(null, "autenticado");
        }
    }
}
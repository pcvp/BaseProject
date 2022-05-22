using BaseApp.Config;
using DTOs.RecuperacaoDeSenha;
using DTOs.Usuarios;
using BaseApp.Services.ApiClient.Base;
using CSharpFunctionalExtensions;
using System;
using System.Threading.Tasks;

namespace BaseApp.Services.ApiClient.RecuperarSenha {

    public class RecuperarSenhaApiClient : BaseApiClient {

        public RecuperarSenhaApiClient() : base(Configuracoes.BaseAddress) {
        }

        protected override string ResourceName => "RecuperacaoDeSenha";

        public Task<Maybe<string>> RecuperacaoDeSenha(string email) {
            return RequestPost<string>(new { Email = email });
        }

    }
}
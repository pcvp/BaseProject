using BaseApp.Config;
using DTOs.Token;
using BaseApp.Services.ApiClient.Base;
using CSharpFunctionalExtensions;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace BaseApp.Services.ApiClient.oAuth {

    public class oAuthClient : BaseApiClient, IoAuthClient {

        public oAuthClient() : base(Configuracoes.BaseAddress) {
        }

        protected override string ResourceName {
            get {
                return Configuracoes.TokenEndpoint;
            }
        }

        //public async Task<oAuthTokenDTO> AtualizarToken(string refreshToken) {
        //    return await ResourceUrl
        //        .PostUrlEncodedAsync(new {
        //            grant_type = "refresh_token",
        //            client_id = Configuracoes.OAuthClientId,
        //            refresh_token = refreshToken
        //        }).ReceiveJson<oAuthTokenDTO>();
        //}

        public async Task<AuthResultDTO> Autenticar(string login, string senha) {
            try {

                var dados = new AuthDTO {
                    Login = login,
                    Senha = senha
                };

                var result = await RequestPost<AuthResultDTO>(dados);                

                if (result.HasValue) {
                    return result.Value;
                }
                return null;
            }
            catch (Exception e) {
                throw;
            }
        }

        //public async Task<oAuthTokenDTO> AutenticarExterno(string provider, string token) {
        //    return await Executar(new Flurl.Url(Configuracoes.DefaultBaseAddress)
        //        .AppendPathSegment("externalLogin")
        //        .PostUrlEncodedAsync(new {
        //            client_id = Configuracoes.oAuthClientId,
        //            client_secret = Configuracoes.oAuthSecret,
        //            provider = provider,
        //            accessToken = token
        //        }).ReceiveJson<oAuthTokenDTO>());
        //}
    }
}
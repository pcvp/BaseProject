using DTOs.Token;
using DTOs.Usuarios;
using BaseApp.Properties;
using BaseApp.Services.ApiClient.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApp.Helpers {

    public static class UsuarioHelper {

        public static void AtualizarToken(AuthResultDTO token) {
            SetAccessToken(token.AccessToken);
            //SetRefreshToken(token.RefreshToken);
            SetExpiracaoToken(token.Expiration);
        }

        public static bool EstaLogado() {
            string accessToken = GetAccessToken();
            var expiracao = GetExpiracaoToken();
            return !string.IsNullOrEmpty(accessToken) && expiracao > DateTime.Now;
        }

        public static string GetAccessToken() {
            return LocalDataStoreHelper.GetAsync(KeysResource.TokenStorageKey).Result;
        }

        public static DateTime? GetExpiracaoToken() {
            return LocalDataStoreHelper.GetAsync<DateTime?>(KeysResource.ExpiracaoTokenStorageKey).Result;
        }

        public static string GetRefreshToken() {
            return LocalDataStoreHelper.GetAsync(KeysResource.RefreshTokenStorageKey).Result;
        }

        public static void Logout() {
            LocalDataStoreHelper.Remove(KeysResource.TokenStorageKey);
            LocalDataStoreHelper.Remove(KeysResource.RefreshTokenStorageKey);
            LocalDataStoreHelper.Remove(KeysResource.ExpiracaoTokenStorageKey);
        }

        public static void SetAccessToken(string value) {
            string key = KeysResource.TokenStorageKey;
            LocalDataStoreHelper.SetAsync(key, value).Wait();
        }

        public static void SetExpiracaoToken(int segundosParaExpirar) {
            DateTime data = DateTime.Now.AddSeconds(segundosParaExpirar);
            SetExpiracaoToken(data);
        }

        public static void SetExpiracaoToken(DateTime data) {
            LocalDataStoreHelper.SetAsync(KeysResource.ExpiracaoTokenStorageKey, data).Wait();
        }

        public static void SetRefreshToken(string refreshToken) {
            LocalDataStoreHelper.SetAsync(KeysResource.RefreshTokenStorageKey, refreshToken).Wait();
        }
            
        public static bool PossuiPermissao(string permissao) => Permissao?.Any(f => f == permissao) ?? false;

        public static List<string> Permissao { get; set; }

        public static Task AtualizarPermissoes() {
            var task = new UsuarioApiClient().ObterPermissoes();

            //task.ContinueWith(permissoes => {
            //    Permissao = permissoes.Result.Value;
            //    MessagingCenter.Send<Application>(Application.Current, KeysResource.MessageCarregarPermissoes);
            //});

            return task;
        }

        public static string? GetLogin() {
            return LocalDataStoreHelper.GetAsync<string?>(KeysResource.LoginStorageKey).Result;
        }

        public static void SetLogin(string login) {
            LocalDataStoreHelper.SetAsync(KeysResource.LoginStorageKey, login).Wait();
        }

        public static UsuarioDetalhesComPerfilDTO GetUsuario() {
            return LocalDataStoreHelper.GetAsync<UsuarioDetalhesComPerfilDTO>(KeysResource.UsuarioStorageKey).Result;
        }

        public static void SetUsuario(UsuarioDetalhesComPerfilDTO usuario) {
            LocalDataStoreHelper.SetAsync(KeysResource.UsuarioStorageKey, usuario).Wait();
        }
    }
}
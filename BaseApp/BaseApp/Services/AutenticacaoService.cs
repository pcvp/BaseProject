using BaseApp.Helpers;
using BaseApp.Services.ApiClient.oAuth;
using BaseApp.Services.ApiClient.Usuario;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseApp.Services {

    public class AutenticacaoService {

        public Task<string> Autenticar(string login, string senha) {
            UsuarioHelper.Logout();

            var taskSource = new TaskCompletionSource<string>();

            var token = new oAuthClient().Autenticar(login, senha).ContinueWith(result => {
                if (!result.IsFaulted && result.Result != null) {
                    UsuarioHelper.AtualizarToken(result.Result);


                    new UsuarioApiClient().ObterUsuarioLogado().ContinueWith((retorno) => {
                        if (retorno.IsFaulted || !retorno.Result.HasValue) return;
                        var usuario = retorno.Result.Value;
                        UsuarioHelper.SetUsuario(usuario);

                        taskSource.SetResult(null);
                    });
                }
                else {
                    string mensagem = "Email e/ou senha incorreto. Tente novamente ou clique em \"Esqueceu a senha ?\" para redefini-la";
                    taskSource.SetException(new Exception(mensagem));
                }
            });

            return taskSource.Task;
        }
    }
}
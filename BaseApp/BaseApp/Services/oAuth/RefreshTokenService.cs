using BaseApp.Helpers;
using BaseApp.Services.ApiClient.oAuth;
using Flurl.Http;
using System.Threading.Tasks;

namespace BaseApp.Services.ApiClient.oAuth {

    public static class RefreshTokenService {
        private static TaskCompletionSource<bool> RefreshTokenTaskCompletionSource = null;
        private static bool IsRefreshingToken = false;

        //public static async Task<bool> AtualizarRefreshToken() {
        //    if (IsRefreshingToken && RefreshTokenTaskCompletionSource != null)
        //        return await RefreshTokenTaskCompletionSource.Task;

        //    RefreshTokenTaskCompletionSource = new TaskCompletionSource<bool>();
        //    IsRefreshingToken = true;

        //    try {
        //        var client = new oAuthClient();
        //        var refreshTokenResponse = await client.AtualizarToken(UsuarioHelper.GetRefreshToken());
        //        UsuarioHelper.AtualizarToken(refreshTokenResponse);
        //        IsRefreshingToken = false;
        //        RefreshTokenTaskCompletionSource.TrySetResult(true);
        //    }
        //    catch (FlurlHttpException) {
        //        IsRefreshingToken = false;
        //        UsuarioHelper.Logout();

        //        //var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
        //        //appDelegate.MainNavigationController.PopToRootViewController(true);

        //        //ValidationHelper.Validate(false, Mensagens.SessaoExpirada);

        //        RefreshTokenTaskCompletionSource.TrySetResult(false);
        //    }

        //    return await RefreshTokenTaskCompletionSource.Task;
        //}
    }
}
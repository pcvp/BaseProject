using DTOs.Token;
using System.Threading.Tasks;

namespace BaseApp.Services.ApiClient.oAuth {
    public interface IoAuthClient {
        Task<AuthResultDTO> Autenticar(string username, string password);

        //Task<oAuthTokenDTO> AtualizarToken(string refreshToken);

        //Task<oAuthTokenDTO> AutenticarExterno(string provider, string token);
    }
}
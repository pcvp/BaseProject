using BaseApp.Helpers;
using BaseApp.ViewModels.Base;
using BaseApp.Views.CadastrarUsuario;
using BaseApp.Views.Login;
using Xamarin.Forms;

namespace BaseApp.ViewModels.Comecando {
    public class ComecandoViewModel : BaseViewModel {
            

        public Command IrParaLoginCommand => new Command(async () => {
            NavigationHelper.NavigationPagePushAsync(new LoginPage());
        });

      
        
        public Command IrParaCadastreseCommand => new Command(async () => {
            NavigationHelper.NavigationPagePushAsync(new CadastrarUsuarioPage());
        });
    }
}

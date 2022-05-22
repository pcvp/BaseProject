using BaseApp.Helpers;
using System;
using Xamarin.Forms;

namespace BaseApp {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
        }

        private void SairClick(object sender, EventArgs e) {
            SairCommand.Execute(null);
        }

        public Command SairCommand = new Command(async () => {
            Shell.Current.FlyoutIsPresented = false;   //Fecha o menu 
            UsuarioHelper.Logout();
            await NavigationHelper.GoToAsync("//comecando");
        });
    }
}

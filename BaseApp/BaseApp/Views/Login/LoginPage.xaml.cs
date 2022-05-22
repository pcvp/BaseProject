using BaseApp.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaseApp.Views.Login {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed() {
            var vm = (LoginViewModel)BindingContext;
            vm.Voltar.Execute(null);
            return true;
        }
    }
}
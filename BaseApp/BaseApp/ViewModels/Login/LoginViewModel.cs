using BaseApp.Helpers;
using BaseApp.Services;
using BaseApp.ViewModels.Base;
using BaseApp.Views.CadastrarUsuario;
using BaseApp.Views.Home;
using BaseApp.Views.RecuperarSenha;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BaseApp.ViewModels.Login {
    public class LoginViewModel : FormularioBaseModel {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o e-mail.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O e-mail deve ter entre 3 a 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        public string Login { get; set; }
        public string ValidacaoLogin { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 a 20 caracteres.")]
        public string Senha { get; set; }
        public string ValidacaoSenha { get; set; }



        public Command FazerLoginCommand => new Command(async () => {
            if (ExisteErrosDeValidacao())
                return;
            
            try {
                MostrarLoading = true;
                Login = Login.ToLower().Trim();
                await new AutenticacaoService().Autenticar(Login, Senha).ContinueWith(async (result) => {
                    if (!result.IsFaulted) {
                        Device.BeginInvokeOnMainThread(async () => {
                            Application.Current.MainPage = new AppShell();
                            await NavigationHelper.GoToAsync("//main");
                        });
                    }
                    else
                        ValidacaoSenha = result.Exception.InnerException.Message;

                    MostrarLoading = false;
                });

            }
            catch (Exception e) {
                MostrarLoading = false; 
                Console.WriteLine(e.Message);
            }
        }) {

        };

        public Command RecuperarSenhaCommand => new Command(async () => {
            NavigationHelper.NavigationPagePushAsync(new RecuperarSenhaPage());
        });

        public Command CadastreseCommand => new Command(async () => {
            NavigationHelper.NavigationPagePushAsync(new CadastrarUsuarioPage());
        });


        #region Validação
        public bool ExisteErrosDeValidacao() {
            var erros = ErrosValidacao();

            if (erros.Any()) {
                ExibeErrosDeValidacao(erros);
                return true;
            }

            return false;
        }

        private void ExibeErrosDeValidacao(List<ValidationResult> erros) {
            ValidacaoLogin = GetMensagemDeErroDaValidacaoSeExistir(erros, "Login");
            ValidacaoSenha = GetMensagemDeErroDaValidacaoSeExistir(erros, "Senha");
        }
        #endregion
    }
}

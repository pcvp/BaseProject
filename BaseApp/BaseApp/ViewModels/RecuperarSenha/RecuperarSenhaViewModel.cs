using BaseApp.Helpers;
using BaseApp.Services.ApiClient.RecuperarSenha;
using BaseApp.ViewModels.Base;
using BaseApp.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BaseApp.ViewModels.RecuperarSenha {
    public class RecuperarSenhaViewModel : FormularioBaseModel {
        public RecuperarSenhaViewModel() {

        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o e-mail.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O e-mail deve ter entre 3 a 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        public string Login { get; set; }
        public string ValidacaoLogin { get; set; }

        public Command VoltarParaOLoginCommand => new Command(async () => {
            VoltarPage.Execute(null);
        });

        public Command RecuperarSenhaCommand => new Command(async () => {
            if (ExisteErrosDeValidacao())
                return;

            MostrarLoading = true;
            new RecuperarSenhaApiClient().RecuperacaoDeSenha(Login).ContinueWith(async (response) => {
                MostrarLoading = false;
                if (FoiSucesso(response)) {
                    await AlertHelper.DisplayAlert("Recuperação de senha", "Em instantes enviaremos um link para redefinir sua senha.", "Ok");
                    VoltarParaOLoginCommand.Execute(null);
                }
                await AlertHelper.DisplayAlert("Recuperação de senha", "Não foi encontrada um conta com o email informado", "Ok");
            });
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
        }
        #endregion
    }
}

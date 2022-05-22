using DTOs.Usuarios;
using BaseApp.Helpers;
using BaseApp.Services.ApiClient.RecuperarSenha;
using BaseApp.ViewModels.Base;
using BaseApp.Views.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BaseApp.ViewModels.CadastrarUsuario {
    public class CadastrarUsuarioViewModel : FormularioBaseModel {
        public string ValidacaoNome { get; set; }
        public string ValidacaoEmail { get; set; }
        public string ValidacaoSenha { get; set; }
        public string ValidacaoTelefone { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 a 100 caracteres.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o e-mail.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O e-mail deve ter entre 3 a 100 caracteres.")]
        [EmailAddress(ErrorMessage =  "O e-mail informado é inválido.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 a 20 caracteres.")]
        public string Senha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o telefone.")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "O telefone deve ter pelo menos 8 digitos.")]
        public string Telefone { get; set; }

        public Command VoltarParaOLoginCommand => new Command(async () => {
            VoltarPage.Execute(null);
        });


        public Command CadastreseCommand => new Command(async () => {
            if (ExisteErrosDeValidacao())
                return;

            MostrarLoading = true;
            new CadastrarUsuarioApiClient().CadastroUsuario(new UsuarioDetalhesDTO(Nome, Email, Senha, Telefone)).ContinueWith(async (response) => {
                MostrarLoading = false;
                if (FoiSucesso(response)) {
                    await AlertHelper.DisplayAlert("Avanutri Recovery", "Conta criada com sucesso", "Ok");
                    VoltarParaOLoginCommand.Execute(null);
                }            
            });
        });
              

        public bool ExisteErrosDeValidacao() {
            var erros = ErrosValidacao();
            
            if (erros.Any()) {
                ExibeErrosDeValidacao(erros);
                return true;
            }

            return false;
        }

        private void ExibeErrosDeValidacao(List<ValidationResult> erros) {
            ValidacaoNome = GetMensagemDeErroDaValidacaoSeExistir(erros, "Nome");
            ValidacaoEmail = GetMensagemDeErroDaValidacaoSeExistir(erros, "Email");
            ValidacaoSenha = GetMensagemDeErroDaValidacaoSeExistir(erros, "Senha");
            ValidacaoTelefone = GetMensagemDeErroDaValidacaoSeExistir(erros, "Telefone");
        }
    }
}

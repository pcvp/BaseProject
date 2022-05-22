using BaseApp.Config;
using BaseApp.Factories;
using BaseApp.Helpers;
using BaseApp.Views.Comecando;
using Flurl.Http;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BaseApp {
    public partial class App : Application {

        public App() {
            InitializeComponent();

            var culture = new System.Globalization.CultureInfo(Configuracoes.CultureInfoName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
                       

            FlurlHttp.Configure(c => {
                //c.DefaultTimeout = TimeSpan.FromMinutes(10);
                c.Timeout = TimeSpan.FromMinutes(10);
                c.BeforeCallAsync = AntesDeTodasAsRequisicoesHttp;
                //c.OnErrorAsync = ErroEmConexoes;
                c.HttpClientFactory = new PollyHttpClientFactory();
            });

            if (UsuarioHelper.EstaLogado()) {
                MainPage = new AppShell();
            } else {
                MainPage = new NavigationPage(new ComecandoPage()) {
                    BarBackgroundColor = ResourceHelper.StaticResourceColor("WhiteColor"),
                    BarTextColor = ResourceHelper.StaticResourceColor("PrimaryColor"),
                    BackgroundColor = ResourceHelper.StaticResourceColor("WhiteColor")
                };
            }
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }

        private async Task AntesDeTodasAsRequisicoesHttp(FlurlCall call) {
            bool isDebug = Debugger.IsAttached;
            if (!call.Request.Url.ToString().Contains(Configuracoes.TokenEndpoint)) {
                if (UsuarioHelper.EstaLogado()) {
                    if (isDebug)
                        Console.WriteLine("[APP] Incluindo token no cabeçalho da requisição.");
                    string token = UsuarioHelper.GetAccessToken();
                    call.Request.Headers.Add("Authorization", $"Bearer {token}");
                }

                if (isDebug)
                    Console.WriteLine($"[APP] Requisição [{call.Request.Verb}] {call.Request.Url}");
            }
        }

    }
}

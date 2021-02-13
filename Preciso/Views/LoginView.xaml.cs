using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void OnTapEsqueciSenha(object sender, System.EventArgs e)
        {

        }

        private void OnTapCriarConta(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AdicionarProfissionalView());
        }
    }
}
using Preciso.ViewModels;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
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
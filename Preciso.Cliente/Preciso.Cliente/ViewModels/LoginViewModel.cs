using Preciso.Cliente.Data;
using Preciso.Cliente.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.Cliente.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly FirebaseUsuarioService firebase;

        public LoginViewModel()
        {
            firebase = new FirebaseUsuarioService();
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        private Command _loginCommand;
        public Command LoginCommand =>
            _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginCommand()));

        private async Task ExecuteLoginCommand()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
            {
                await App.Current.MainPage.DisplayAlert("", "Informe o email e/ou senha", "Ok");
            }
            else
            {
                var loginUsuario = await firebase.VerificaLogin(Email);

                if (loginUsuario != null)
                {
                    if (Email == loginUsuario.Email && Senha == loginUsuario.Senha)
                        await App.Current.MainPage.Navigation.PushAsync(new CadastroUsuarioView());
                    else
                        await App.Current.MainPage.DisplayAlert("Erro", "Informe o email/senha correto(s)", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Usuátio não cadastrado", "Ok");
                }
            }
        }
    }
}

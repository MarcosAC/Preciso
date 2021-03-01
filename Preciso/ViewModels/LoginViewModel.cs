using Preciso.Data;
using Preciso.Views;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly FirebasePrecisoService firebase;

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

        public LoginViewModel()
        {
            firebase = new FirebasePrecisoService();
        }

        private Command _loginCommand;
        public Command LoginCommand =>
            _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginCommand()));

        private async Task ExecuteLoginCommand()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
            {
                await App.Current.MainPage.DisplayAlert("", "Informe o email e / ou senha", "Ok");
            }
            else
            {
                var loginProfissional = await firebase.VerificaLogin(Email);

                if (loginProfissional != null)
                {
                    if (Email == loginProfissional.Email && Senha == loginProfissional.Senha)
                        await App.Current.MainPage.Navigation.PushAsync(new ListaServicosView());
                    else
                        await App.Current.MainPage.DisplayAlert("Erro", "Informe o email/senha correto(s)", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Profissional não cadastrado", "Ok");
                }
            }
        } 
    }
}

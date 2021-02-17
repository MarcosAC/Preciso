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
            var profissionais = await firebase.ListaProfissionais();

            var loginProfissional = profissionais.Where(profissional => profissional.Email == Email).FirstOrDefault();

            if (loginProfissional == null)
            {
                await App.Current.MainPage.DisplayAlert("", "Profissional não cadastrado", "Ok");
                return;
            }

            if (loginProfissional.Senha == Senha )
                await App.Current.MainPage.Navigation.PushAsync(new ListaServicosView());
            else
                await App.Current.MainPage.DisplayAlert("Erro", "Senha incorreta", "Ok"); 
        } 
    }
}

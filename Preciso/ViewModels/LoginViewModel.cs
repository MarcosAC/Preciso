using Preciso.Data;
using Preciso.Data.LocalData.Repositorio;
using Preciso.Data.Model;
using Preciso.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly LoginService _loginService;
        private readonly IRepositorioProfissional _repositorioProfissional;

        public LoginViewModel(LoginService loginService, IRepositorioProfissional repositorioProfissional)
        {
            _loginService = loginService;
            _repositorioProfissional = repositorioProfissional;
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
                var loginProfissional = await _loginService.VerificaLogin(Email);

                var profissional = new Profissional
                {
                    Nome = loginProfissional.Nome,
                    Cpf = loginProfissional.Cpf,
                    Endereco = loginProfissional.Endereco,
                    TipoProfissional = loginProfissional.TipoProfissional
                };

                if (loginProfissional != null)
                {
                    if (Email == loginProfissional.Email && Senha == loginProfissional.Senha)
                    {
                        _repositorioProfissional.AdicionarFuncionario(profissional);
                        await App.Current.MainPage.Navigation.PushAsync(new MenuPrincipalView());
                    }                        
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

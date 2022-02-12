using Preciso.Data;
using Preciso.Data.LocalData.Repositorio;
using Preciso.Data.Model;
using Preciso.DTOs;
using Preciso.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly LoginService _loginService;
        private readonly RepositorioProfissional _repositorioProfissional;

        public LoginViewModel()
        {
            _loginService = new LoginService();
            _repositorioProfissional = new RepositorioProfissional();
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

                if (loginProfissional != null)
                {
                    if (Email == loginProfissional.Email && Senha == loginProfissional.Senha)
                    {
                        _repositorioProfissional.AdicionarFuncionario(DadosProfissional(loginProfissional));                       
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
        
        private Profissional DadosProfissional(ProfissionalDto profissionalDTO)
        {
            var profissional = new Profissional
            {
                Nome = profissionalDTO.Nome,
                Cpf = profissionalDTO.Cpf,
                Celular = profissionalDTO.Celular,
                Endereco = profissionalDTO.Endereco,
                FormaPagamento = profissionalDTO.FormaPagamento,
                Email = profissionalDTO.Email,
                Senha = profissionalDTO.Senha,
                TipoProfissional = profissionalDTO.TipoProfissional
            };

            return profissional;
        }
    }
}

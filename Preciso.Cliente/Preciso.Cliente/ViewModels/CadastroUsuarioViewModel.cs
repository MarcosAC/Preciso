using Preciso.Cliente.Data;
using Preciso.Cliente.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.Cliente.ViewModels
{
    public class CadastroUsuarioViewModel : BaseViewModel
    {
        private readonly FirebaseService firebase;

        public CadastroUsuarioViewModel()
        {
            firebase = new FirebaseService();
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _endereco;
        public string Endereco
        { 
            get => _endereco;
            set => SetProperty(ref _endereco, value);
        }

        private string _celular;
        public string Celular
        { 
            get => _celular;
            set => SetProperty(ref _celular, value);
        }

        private string _email;
        public string Email
        { 
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private Command __salvarCommand;
        public Command EnviarSolicitacaoServicoCommand =>
            __salvarCommand ?? (__salvarCommand = new Command(async () => await ExecuteSalvarCommand()));

        private async Task ExecuteSalvarCommand()
        {
            var usuario = new Usuario
            {
                Nome = Nome,
                Endereco = Endereco,
                Celular = Celular,
                Email = Email
            };

            if (usuario != null)
            {
                //await firebase.SolicitarServico(usuario);
                await App.Current.MainPage.DisplayAlert("Cadastrar Usuário", "Sucesso ao cadastrar usuário", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Cadastrar Usuário", "Erro ao cadastrar usuário", "Ok");
            }
        }
    }
}

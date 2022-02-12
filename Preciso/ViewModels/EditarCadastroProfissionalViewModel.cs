using Preciso.Data;
using Preciso.Data.LocalData.Repositorio;
using Preciso.DTOs;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.ViewModels
{
    public class EditarCadastroProfissionalViewModel : BaseViewModel
    {
        private readonly ProfissionalService profissionalService;
        private readonly RepositorioProfissional repositorioProfissional;

        public EditarCadastroProfissionalViewModel()
        {
            profissionalService = new ProfissionalService();
            repositorioProfissional = new RepositorioProfissional();

            DadosProfissional();
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }

        private string _celular;
        public string Celular
        {
            get => _celular;
            set => SetProperty(ref _celular, value);
        }

        private string _endereco;
        public string Endereco
        {
            get => _endereco;
            set => SetProperty(ref _endereco, value);
        }

        private string _formaPagamento;
        public string FormaPagamento
        {
            get => _formaPagamento;
            set => SetProperty(ref _formaPagamento, value);
        }

        private string _tipoProfissional;
        public string TipoProfissional
        {
            get => _tipoProfissional;
            set => SetProperty(ref _tipoProfissional, value);
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

        private bool _ativo;
        public bool Ativo
        {
            get => _ativo;
            set => SetProperty(ref _ativo, value);
        }

        private Command _editarDadosProfissionalCommand;
        public Command EditarDadosProfissionalCommand =>
            _editarDadosProfissionalCommand ?? (
            _editarDadosProfissionalCommand = new Command(async () => 
            await ExecuteEditarDadosProfissionalCommand()));

        private async Task ExecuteEditarDadosProfissionalCommand()
        {
            var profissioanalDTO = new ProfissionalDto
            {
                Nome = Nome,
                Cpf = Cpf,
                Celular = Celular,
                Endereco = Endereco,
                FormaPagamento = FormaPagamento,
                TipoProfissional = TipoProfissional,
                Email = Email,
                Senha = Senha,
                //DataAtivacao = DataAtivacao
            };

            await profissionalService.EditarProfissional(profissioanalDTO);
        }

        private void DadosProfissional()
        {
            var profissionalObitido = repositorioProfissional.ListaProfissionais();

            if (profissionalObitido != null)
            {
                foreach (var profissional in profissionalObitido)
                {
                    Nome = profissional.Nome;
                    Cpf = profissional.Cpf;
                    Celular = profissional.Celular;
                    Endereco = profissional.Endereco;
                    FormaPagamento = profissional.FormaPagamento;
                    TipoProfissional = profissional.TipoProfissional;
                    Email = profissional.Email;
                    Senha = profissional.Senha;
                }
            }
        }
    }
}

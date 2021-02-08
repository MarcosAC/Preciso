using Preciso.Data;
using Preciso.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.ViewModels
{
    public class AdicionarProfissionalViewModel : BaseViewModel
    {
        private readonly FirebaseService firebase;

        private string _cpf;
        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
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

        //private TipoProfissional _tipoProfissional;
        //public TipoProfissional TipoProfissional 
        //{ 
        //    get => _tipoProfissional;
        //    set => SetProperty(ref _tipoProfissional, value);
        //}

        private string _tipoProfissional;
        public string TipoProfissional
        {
            get => _tipoProfissional;
            set => SetProperty(ref _tipoProfissional, value);
        }

        private bool _ativo;
        public bool Ativo
        { 
            get => _ativo;
            set => SetProperty(ref _ativo, value);
        }

        private DateTime _dataAtivacao;
        public DateTime DataAtivacao
        { 
            get => _dataAtivacao;
            set => SetProperty(ref _dataAtivacao, value);
        }

        private DateTime _dataDesativado;
        public DateTime DataDesativado
        { 
            get => _dataDesativado;
            set => SetProperty(ref _dataDesativado, value);
        }

        public AdicionarProfissionalViewModel()
        {
            firebase = new FirebaseService();
        }

        private Command _salvarDadosProfissionalCommand;
        public Command SalvarDadosProfiossionalCommand =>
            _salvarDadosProfissionalCommand ?? (_salvarDadosProfissionalCommand = new Command(async () => ExecuteSalvarDadosProfissionaisCommand()));

        private async Task ExecuteSalvarDadosProfissionaisCommand()
        {
            var profissioanal = new Profissional
            {
                Cpf = Cpf,
                Nome = Nome,
                Celular = Celular,
                Email = Email,
                Endereco = Endereco,
                FormaPagamento = FormaPagamento,
                TipoProfissional = TipoProfissional,
                DataAtivacao = DataAtivacao
            };

            if (profissioanal == null)
            {
                await App.Current.MainPage.DisplayAlert("Cadastrar Profissional", "Erro ao cadastrar profissional", "Ok");
            }
            else
            {
                await firebase.CadastrarProfissional(profissioanal);
                await App.Current.MainPage.DisplayAlert("Cadastrar Servico", "Sucesso ao cadastrar servico", "Ok");
            }
        }

        private Command _editarDadosProfissionalCommand;
        public Command EditarDadosProfissionalCommand =>
            _editarDadosProfissionalCommand ?? (_editarDadosProfissionalCommand = new Command(async () => ExecuteEditarDadosProfissionalCommand()));

        private async Task ExecuteEditarDadosProfissionalCommand()
        {
            //TODO - Fazer API e camada de DataBase.
        }
    }
}

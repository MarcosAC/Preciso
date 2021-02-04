using Preciso.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.Profissional.ViewModels
{
    public class AdicionarProfissionalViewModel : BaseViewModel
    {
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

        private TipoProfissional _tipoProfissional;
        public TipoProfissional TipoProfissional 
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

        private Command _salvarDadosProfissionalCommand;
        public Command SalvarDadosProfiossionalCommand =>
            _salvarDadosProfissionalCommand ?? (_salvarDadosProfissionalCommand = new Command(async () => ExecuteSalvarDadosProfissionaisCommand()));

        private async Task ExecuteSalvarDadosProfissionaisCommand()
        {
            //TODO - Fazer API e camada de DataBase.
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

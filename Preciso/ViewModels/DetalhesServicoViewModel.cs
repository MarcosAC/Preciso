using Preciso.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Preciso.ViewModels
{
    public class DetalhesServicoViewModel : BaseViewModel
    {
        private ObservableCollection<Servico> _servicos;
        public Servico _servicoSelecionado;

        public DetalhesServicoViewModel(Servico servicoSelecionado)
        {
            _servicoSelecionado = servicoSelecionado;
            //ListaServicos();
        }

        public string Titulo
        {
            get { return _servicoSelecionado.Titulo; }
            set
            {
                _servicoSelecionado.Titulo = value;
                OnPropertyChanged();
            }
        }

        public DateTime DataSolicitacao
        {
            get { return _servicoSelecionado.DataSolicitacao; }
            set
            {
                _servicoSelecionado.DataSolicitacao = value;
                OnPropertyChanged();
            }
        }

        public string NomeCliente
        {
            get { return _servicoSelecionado.NomeCliente; }
            set
            {
                _servicoSelecionado.NomeCliente = value;
                OnPropertyChanged();
            }
        }

        public string ContatoCliente
        {
            get { return _servicoSelecionado.ContatoCliente; }
            set
            {
                _servicoSelecionado.ContatoCliente = value;
                OnPropertyChanged();
            }
        }

        public string Descricao
        {
            get { return _servicoSelecionado.Descricao; }
            set
            {
                _servicoSelecionado.Descricao = value;
                OnPropertyChanged();
            }
        }        

        //public ObservableCollection<Servico> Servicos
        //{ 
        //    get => _servicos;
        //    set => SetProperty(ref _servicos, value);
        //}

        //public async Task<ObservableCollection<Servico>> ListaServicos()
        //{
        //    //TODO - Fazer API e camada de DataBase.
        //    return Servicos;
        //}
    }
}

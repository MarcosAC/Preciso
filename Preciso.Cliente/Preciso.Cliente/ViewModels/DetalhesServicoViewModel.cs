using Preciso.Cliente.Models;

namespace Preciso.Cliente.ViewModels
{
    public class DetalhesServicoViewModel : BaseViewModel
    {
        public Servico _servicoSelecionado;

        public DetalhesServicoViewModel(Servico servicoSelecionado)
        {
            _servicoSelecionado = servicoSelecionado;
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

        //public DateTime DataSolicitacao
        //{
        //    get { return _servicoSelecionado.DataSolicitacao; }
        //    set
        //    {
        //        _servicoSelecionado.DataSolicitacao = value;
        //        OnPropertyChanged();
        //    }
        //}

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
    }
}
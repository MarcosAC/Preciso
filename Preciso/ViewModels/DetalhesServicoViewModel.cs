using Preciso.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Preciso.Profissional.ViewModels
{
    public class DetalhesServicoViewModel : BaseViewModel
    {
        private ObservableCollection<Servico> _servicos;
        public ObservableCollection<Servico> Servicos
        { 
            get => _servicos;
            set => SetProperty(ref _servicos, value);
        }

        public DetalhesServicoViewModel()
        {
            ListaServicos();
        }

        public async Task<ObservableCollection<Servico>> ListaServicos()
        {
            //TODO - Fazer API e camada de DataBase.
            return Servicos;
        }
    }
}

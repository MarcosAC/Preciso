using Preciso.Models;
using Preciso.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Preciso.Profissional.ViewModels
{
    public class TipoProfissionalViewModel : BaseViewModel
    {
        private ObservableCollection<TipoProfissional> _tiposProfissionais;
        public ObservableCollection<TipoProfissional> TiposProfissionais
        {
            get => _tiposProfissionais;
            set => SetProperty(ref _tiposProfissionais, value);
        }

        public TipoProfissionalViewModel()
        {
            ListaTiposProfssionais();
        }

        public async Task<ObservableCollection<TipoProfissional>> ListaTiposProfssionais()
        {
            //TODO - Fazer API e camada de DataBase.
            return TiposProfissionais;
        }
    }
}

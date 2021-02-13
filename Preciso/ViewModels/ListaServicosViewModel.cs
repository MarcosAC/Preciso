using Preciso.Data;
using Preciso.Models;
using System.Collections.ObjectModel;

namespace Preciso.ViewModels
{
    public class ListaServicosViewModel : BaseViewModel
    {
        private readonly FirebasePrecisoService firebase;

        public ObservableCollection<Servico> Servicos { get; set; }

        public ListaServicosViewModel()
        {
            firebase = new FirebasePrecisoService();
            Servicos = CarregarServicos();            
        }

        private ObservableCollection<Servico> CarregarServicos()
        {
            return firebase.ListaServicos();
        }
    }
}

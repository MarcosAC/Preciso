using Preciso.Data;
using Preciso.Models;
using System.Collections.ObjectModel;

namespace Preciso.ViewModels
{
    public class ListaServicosViewModel : BaseViewModel
    {
        private readonly FirebaseService firebase;

        public ObservableCollection<Servico> Servicos { get; set; }

        public ListaServicosViewModel()
        {
            firebase = new FirebaseService();
            Servicos = CarregarServicos();            
        }

        private ObservableCollection<Servico> CarregarServicos()
        {
            return firebase.ListaServicos();
        }
    }
}

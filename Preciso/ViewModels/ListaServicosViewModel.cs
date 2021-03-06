using Preciso.Data;
using Preciso.Models;
using Preciso.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        private Command _selecionarServicoCommand;
        public Command SelecionarServicoCommand =>
            _selecionarServicoCommand ?? (_selecionarServicoCommand = new Command<Servico>(async servico => await ExecuteSelecionarServicoCommand(servico)));

        private async Task ExecuteSelecionarServicoCommand(Servico servicoSelecionado)
        {
            if (servicoSelecionado == null)
                return;

            await App.Current.MainPage.Navigation.PushAsync(new DetalheServicoView(servicoSelecionado));
        }
    }
}

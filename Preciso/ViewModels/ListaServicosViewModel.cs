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
        private readonly ServicoService servicoService;

        public ObservableCollection<Servico> Servicos { get; set; }

        public ListaServicosViewModel()
        {
            servicoService = new ServicoService();
            Servicos = CarregarServicos();
        }

        private ObservableCollection<Servico> CarregarServicos()
        {
            return servicoService.ListaServicos();
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

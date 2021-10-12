using Preciso.Cliente.Data;
using Preciso.Cliente.Models;
using Preciso.Cliente.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Preciso.Cliente.ViewModels
{
    public class ListaServicosViewModel
    {
        private readonly SolicitarServicoService solicitarServicoService;

        public ObservableCollection<Servico> Servicos { get; set; }

        private ObservableCollection<Servico> CarregarServicos()
        {
            return solicitarServicoService.ListaServicosSolicitados();
        }

        public ListaServicosViewModel()
        {
            solicitarServicoService = new SolicitarServicoService();
            Servicos = CarregarServicos();
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

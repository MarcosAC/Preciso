using Preciso.Models;
using Preciso.ViewModels;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class DetalheServicoView : ContentPage
    {
        public DetalheServicoView(Servico servicoSelecionado)
        {
            InitializeComponent();

            BindingContext = new DetalhesServicoViewModel(servicoSelecionado);
        }
    }
}
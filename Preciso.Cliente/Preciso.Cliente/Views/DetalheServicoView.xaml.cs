using Preciso.Cliente.Models;
using Preciso.Cliente.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Cliente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheServicoView : ContentPage
    {
        public DetalheServicoView(Servico servicoSelecionado)
        {
            InitializeComponent();

            BindingContext = new DetalheServicoViewModel(servicoSelecionado);
        }
    }
}
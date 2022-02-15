using Preciso.Cliente.ViewModels;
using Xamarin.Forms;

namespace Preciso.Cliente.Views
{
    public partial class SolicitarServicoView : ContentPage
    {
        public SolicitarServicoView()
        {
            InitializeComponent();

            BindingContext = new SolicitarServicoViewModel();
        }
    }
}
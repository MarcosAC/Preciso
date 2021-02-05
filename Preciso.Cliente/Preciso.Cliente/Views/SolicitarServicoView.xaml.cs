using Preciso.Cliente.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Cliente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SolicitarServicoView : ContentPage
    {
        public SolicitarServicoView()
        {
            InitializeComponent();

            BindingContext = new SolicitarServicoViewModel();
        }
    }
}
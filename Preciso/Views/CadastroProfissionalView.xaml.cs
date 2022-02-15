using Preciso.ViewModels;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class CadastroProfissionalView : ContentPage
    {
        public CadastroProfissionalView()
        {
            InitializeComponent();

            BindingContext = new CadastroProfissionalViewModel();
        }
    }
}
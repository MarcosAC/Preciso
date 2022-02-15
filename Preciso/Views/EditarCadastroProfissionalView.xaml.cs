using Preciso.ViewModels;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class EditarCadastroProfissionalView : ContentPage
    {
        public EditarCadastroProfissionalView()
        {
            InitializeComponent();

            BindingContext = new EditarCadastroProfissionalViewModel();
        }
    }
}
using Preciso.Cliente.ViewModels;
using Xamarin.Forms;

namespace Preciso.Cliente.Views
{
    public partial class CadastroUsuarioView : ContentPage
    {
        public CadastroUsuarioView()
        {
            InitializeComponent();

            BindingContext = new CadastroUsuarioViewModel();
        }
    }
}
using Preciso.ViewModels;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class ListaServicosView : ContentPage
    {
        public ListaServicosView()
        {
            InitializeComponent();

            BindingContext = new ListaServicosViewModel();
        }
    }
}
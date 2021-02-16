using Preciso.ViewModels;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class AdicionarProfissionalView : ContentPage
    {
        public AdicionarProfissionalView()
        {
            InitializeComponent();

            BindingContext = new AdicionarProfissionalViewModel();
        }
    }
}
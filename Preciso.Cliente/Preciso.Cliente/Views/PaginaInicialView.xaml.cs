using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Cliente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicialView : ContentPage
    {
        public PaginaInicialView()
        {
            InitializeComponent();
        }

        private void On_ClickedBtnPreciso(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SolicitarServicoView());
        }
    }
}
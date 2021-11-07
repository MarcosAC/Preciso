using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipalView : ContentPage
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        private void IrMinhaConta(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroProfissionalView());
        }

        private void IrListaServicos(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ListaServicosView());
        }

        private void IrMeusServicos(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ListaServicosView());
        }        
    }
}
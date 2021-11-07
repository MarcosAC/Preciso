using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Cliente.Views
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
            App.Current.MainPage.Navigation.PushAsync(new CadastroUsuarioView());
        }

        private void IrSolicitarServico(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SolicitarServicoView());
        }

        private void IrMeusServicos(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ListaServicosView());
        }
    }
}
using Preciso.Cliente.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Cliente
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CadastroClienteView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using System;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class ListaServicosView : ContentPage
    {
        public ListaServicosView()
        {
            InitializeComponent();
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new DetalheServicoView());
        }
    }
}
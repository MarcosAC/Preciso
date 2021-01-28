using System;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class ListServicespageView : ContentPage
    {
        public ListServicespageView()
        {
            InitializeComponent();
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ServicesDetailsPageView());
        }
    }
}
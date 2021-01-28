using System;
using Xamarin.Forms;

namespace Preciso.Views
{
    public partial class StartPageView : ContentPage
    {
        public StartPageView()
        {
            InitializeComponent();
        }

        private void On_ClickedBtnPreciso(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new NeedServicePageView());
        }

        private void On_ClickedBtnProfissional(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ListServicespageView());
        }
    }
}
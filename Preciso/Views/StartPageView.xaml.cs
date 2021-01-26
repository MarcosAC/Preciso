﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPageView : ContentPage
    {
        public StartPageView()
        {
            InitializeComponent();
        }

        private void On_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new NeedServicePage());
        }
    }
}
﻿using Preciso.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPageView());
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

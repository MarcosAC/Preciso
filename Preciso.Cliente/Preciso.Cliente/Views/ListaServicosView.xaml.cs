﻿using Preciso.Cliente.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Preciso.Cliente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaServicosView : ContentPage
    {
        public ListaServicosView()
        {
            InitializeComponent();

            ViewModel = new ListaServicosViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ListaServicosViewModel();
        }

        public ListaServicosViewModel ViewModel
        {
            get { return BindingContext as ListaServicosViewModel; }
            set { BindingContext = value; }
        }

        private void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                ViewModel.SelecionarServicoCommand.Execute(e.SelectedItem);

            ListaServicos.SelectedItem = null;
        }
    }
}
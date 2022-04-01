using System;
using MeteoAppSkeleton.ViewModels;
using Xamarin.Forms;

namespace MeteoAppSkeleton.Views
{
    public partial class MeteoListPage : ContentPage
    {
        public MeteoListPage()
        {
            InitializeComponent();
            BindingContext = new MeteoListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void OnItemAdded(object sender, EventArgs e)
        {
            DisplayAlert("Messaggio", "Testo", "OK");
        }

        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Navigation.PushAsync(new MeteoItemPage()
                {
                    BindingContext = e.SelectedItem as Models.Entry
                });
            }
        }
    }
}
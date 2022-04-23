using System;
using Xamarin.Forms;

namespace MeteoApp
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

        async void OnItemAdded(object sender, EventArgs e)
        {
            System.Random random = new System.Random();
            string city = await DisplayPromptAsync("1. Inserisci nome citta", " ");
            string country = await DisplayPromptAsync("2. Inserisci nome nazione", " ");
            Location addedLocation = new Location
            {
                ID = random.Next(),
                CityName = city,
                CountryName = country
            };
            
            MeteoListViewModel.addLocationToList(addedLocation);
        }

        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Navigation.PushAsync(new MeteoItemPage()
                {
                    //Location location = (Location) e
                    BindingContext = new MeteoItemViewModel(e.SelectedItem as Location)
                }) ;
            }
        }
    }
}

using System;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace MeteoApp
{
    public partial class MeteoListPage : ContentPage
    {
        public MeteoListPage()
        {
            InitializeComponent();
            GetLocation();
            BindingContext = new MeteoListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        //Qui viene gestita la parte del click su + 
        //Aggiunta citta alla lista
        async void OnItemAdded(object sender, EventArgs e)
        {
            System.Random random = new System.Random();
            string city = await DisplayPromptAsync("1. Inserisci nome citta", " ");
            string country = await DisplayPromptAsync("2. Inserisci nome nazione", " ");


            if(city.Length == 0 || country.Length == 0)
            {
                await DisplayAlert("Errore", "Campo citta o nazione lasciati in bianco", "Ok");
            }
            else
            {
                Location addedLocation = new Location
                {
                    ID = random.Next(),
                    CityName = city,
                    CountryName = country,
                    Latitude = 100,
                    Longitude = 200
                };

                MeteoListViewModel.addLocationToList(addedLocation);
            }

        }


        async void GetLocation()
        {
            var locator = CrossGeolocator.Current;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            System.Random random = new System.Random();
            Location location = new Location
            {
                ID = random.Next(),
                CityName = "Current location",
                CountryName = "",
                Latitude = position.Latitude,
                Longitude = position.Longitude
            };

            MeteoListViewModel.addLocationToList(location);
        }

        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Location location = (Location)e.SelectedItem;
                Navigation.PushAsync(new MeteoItemPage(location.CityName, location.CountryName, location.Latitude, location.Longitude)
                {
                    //Binda il contesto e passa per il costruttore del MeteoItemViewModel.cs
                    BindingContext = new MeteoItemViewModel(e.SelectedItem as Location)
                }) ;
            }
        }
    }
}

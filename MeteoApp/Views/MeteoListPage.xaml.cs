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
                    CountryName = country
                };

                MeteoListViewModel.addLocationToList(addedLocation);
            }

        }

        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Location location = (Location)e.SelectedItem;
                Navigation.PushAsync(new MeteoItemPage(location.CityName, location.CountryName)
                {
                    //Binda il contesto e passa per il costruttore del MeteoItemViewModel.cs
                    BindingContext = new MeteoItemViewModel(e.SelectedItem as Location)
                }) ;
            }
        }
    }
}

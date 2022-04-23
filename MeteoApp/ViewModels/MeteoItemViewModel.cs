using MeteoApp.Helpers;
using MeteoApp.Models;
using MeteoApp.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using Xamarin.Essentials;


namespace MeteoApp
{
    public class MeteoItemViewModel : BaseViewModel
    {
        
        public MeteoItemViewModel(Location location)
        {
            
        }

        
        WeatherService WeatherService { get; } = new WeatherService();

        string location = Settings.City;
        
        public string Location
        {
            get { return location; }
            set
            {
                Settings.City = value;
                OnPropertyChanged();
                
            }
        }


        bool isImperial = Settings.IsImperial;
        public bool IsImperial
        {
            get { return isImperial; }
            set
            {
                Settings.IsImperial = value;
                OnPropertyChanged();
            }
        }


        string temp = string.Empty;
        public string Temp
        {
            get { return temp; }
            set {
                OnPropertyChanged();
            }
        }

        string condition = string.Empty;
        public string Condition
        {
            get { return condition; }
            set { 
                OnPropertyChanged();  }
        }


        WeatherForecastRoot forecast;
        public WeatherForecastRoot Forecast
        {
            get { return forecast; }
            set { forecast = value; OnPropertyChanged(); }
        }


        ICommand getWeather;
        public ICommand GetWeatherCommand =>
                getWeather ??
                (getWeather = new Command(async () => await ExecuteGetWeatherCommand()));

        private async Task ExecuteGetWeatherCommand()
        {
           
            
                WeatherRoot weatherRoot = null;
                var units = IsImperial ? Units.Imperial : Units.Metric;


                
                    //Get weather by city
                    weatherRoot = await WeatherService.GetWeather(Location.Trim(), units);
                


                //Get forecast based on cityId
                Forecast = await WeatherService.GetForecast(weatherRoot.CityId, units);

                var unit = IsImperial ? "F" : "C";
                Temp = $"Temp: {weatherRoot?.MainWeather?.Temperature ?? 0}°{unit}";
                Condition = $"{weatherRoot.Name}: {weatherRoot?.Weather?[0]?.Description ?? string.Empty}";

                await TextToSpeech.SpeakAsync(Temp + " " + Condition);
            
        }
    }
}
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        public MeteoItemPage(string city, string country)
        {
            InitializeComponent();
            _ = GetWeatherAsync(city, country);

        }

        private async Task GetWeatherAsync(string cityName, string country)
        {

            var httpClient = new HttpClient();

            var content = await httpClient.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?q=" + cityName + ","+country+"&appid=e156fc1592d15fd93d5e9c27c6fec654");

            var weather1 = JObject.Parse(content);
            
            var tempAct = (float)weather1["main"]["temp"] - 273.15;
            var tempMin = (float)weather1["main"]["temp_min"] - 273.15;
            var tempMax = (float)weather1["main"]["temp_max"] - 273.15;

            City.Text = (string)weather1["name"] + " (" + (string)weather1["sys"]["country"] + ")";

            string uriImage = "http://openweathermap.org/img/wn/"+ (string)weather1["weather"][0]["icon"]+"@2x.png";

            Image.Source = new UriImageSource
            {
                Uri = new Uri(uriImage)
            };
            
            Temp.Text = String.Format("{0:0.0}", tempAct) + "°C"; 
            TempMinMax.Text = String.Format("{0:0.0}", tempMin) + "°C/" + String.Format("{0:0.0}", tempMax) + "°C";
            Wind.Text = "Wind speed: " + (string)weather1["wind"]["speed"] + " m/s";
            Humidity.Text = "Humidity: " + (string)weather1["main"]["humidity"] + "%";
            Pressure.Text = "Pressure: " + (string)weather1["main"]["pressure"] + "Ha";

        }
    }
}

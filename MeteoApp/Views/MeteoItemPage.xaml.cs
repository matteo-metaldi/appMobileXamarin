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
        public MeteoItemPage(string city, string country, double latitude, double longitude)
        {
            InitializeComponent();
            _ = GetWeatherAsync(city, country, latitude, longitude);

        }

        private async Task GetWeatherAsync(string cityName, string country, double latitude, double longitude)
        {
            var httpClient = new HttpClient();

            string content;
            if (latitude == 100 && longitude == 200)
            {
                content = await httpClient.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "," + country + "&appid=e156fc1592d15fd93d5e9c27c6fec654");

            }
            else
            {
                content = await httpClient.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat="+latitude +"&lon="+longitude+"&appid=e156fc1592d15fd93d5e9c27c6fec654");
            }

            var weather = JObject.Parse(content);
            
            var tempAct = (float)weather["main"]["temp"] - 273.15;
            var tempMin = (float)weather["main"]["temp_min"] - 273.15;
            var tempMax = (float)weather["main"]["temp_max"] - 273.15;

            City.Text = (string)weather["name"] + " (" + (string)weather["sys"]["country"] + ")";

            string uriImage = "https://openweathermap.org/img/wn/"+ (string)weather["weather"][0]["icon"]+"@4x.png";

            Image.Source = new UriImageSource
            {
                Uri = new Uri(uriImage)

            };
            
            Temp.Text = String.Format("{0:0.0}", tempAct) + "°C"; 
            TempMinMax.Text = String.Format("{0:0.0}", tempMin) + "°C/" + String.Format("{0:0.0}", tempMax) + "°C";
            Wind.Text = "Wind speed: " + (string)weather["wind"]["speed"] + " m/s";
            Humidity.Text = "Humidity: " + (string)weather["main"]["humidity"] + "%";
            Pressure.Text = "Pressure: " + (string)weather["main"]["pressure"] + "Ha";

        }
    }
}

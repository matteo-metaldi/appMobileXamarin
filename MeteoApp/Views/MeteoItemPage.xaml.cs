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

        private String weather;
        public MeteoItemPage()
        {
            InitializeComponent();
            _ = GetWeatherAsync();

        }

        public String Weather {
            get { return weather; } 
            set
            {
                //SetProperty(ref location, value);
                weather = value;
                OnPropertyChanged();
            } 
        }

        ICommand getWeather;
        public ICommand GetWeatherCommand =>
                getWeather ??
                (getWeather = new Command(async () => await GetWeatherAsync()));

        private async Task GetWeatherAsync()
        {

            var httpClient = new HttpClient();

            var content = await httpClient.GetStringAsync("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");

            var weather1 = JObject.Parse(content);

            Console.Write(weather);

           // weather = weather1["weather"][0]["main"];



           // Weather.Text = (string)esempio;

        }
    }
}

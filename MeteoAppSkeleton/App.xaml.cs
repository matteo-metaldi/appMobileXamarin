using MeteoAppSkeleton.Views;
using Xamarin.Forms;

namespace MeteoAppSkeleton
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            
            var nav = new NavigationPage(new MeteoListPage())
            {
                BarBackgroundColor = Color.LightGreen,
                BarTextColor = Color.White
            };

            //var nav = new MeteoListPage();

            MainPage = nav;
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

using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using Xamarin.Essentials;

namespace MeteoApp
{
    public class MeteoItemViewModel : BaseViewModel
    {
        public Location ActualLocation
        {
            get; set;
        }

        public MeteoItemViewModel(Location location)
        {
            ActualLocation = location;
        }
    }
}
namespace MeteoApp
{
    public class MeteoItemViewModel : BaseViewModel
    {
        Location _location;

        public Location Location
        {

            get { return _location;  }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        public MeteoItemViewModel(Location location)
        {
            Location = location;
            
        }
    }
}
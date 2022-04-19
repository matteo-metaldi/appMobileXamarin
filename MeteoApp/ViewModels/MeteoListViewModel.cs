using System;
using System.Collections.ObjectModel;

namespace MeteoApp
{
    public class MeteoListViewModel : BaseViewModel
    {
        static ObservableCollection<Location> _entries;

        public ObservableCollection<Location> Locations
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public MeteoListViewModel()
        {
            Locations = new ObservableCollection<Location>();

            for (var i = 0; i < 10; i++)
            {
                var e = new Location
                {
                    ID = i,
                    CityName = "Entry " + i
                };

                Locations.Add(e);
                
            }
        }

        public static void addLocationToList(Location locationAdd)
        {
            Console.WriteLine("Hello");
            Console.WriteLine(locationAdd.CountryName);
            Console.WriteLine(locationAdd.CityName);
            _entries.Add(locationAdd);
        }
    }
}

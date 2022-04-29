using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

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
        }

        public static void loadListFromDatabase()
        {
            List<Location> location = App.Database.GetItemsAsync().Result;

            location.ForEach(l => _entries.Add(l));
        }

        public static void addLocationToList(Location locationAdd)
        {
            _entries.Add(locationAdd);
            if (locationAdd.CityName != "Current location")
            {
                App.Database.SaveItemAsync(locationAdd);
            }
        }
    }
}

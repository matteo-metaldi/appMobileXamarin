﻿using System;
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
        }

        //Metodo che aggiunge alla lista la location attuale
        //TODO RIMPIAZZARE CON IL DATABASE
        public static void addLocationToList(Location locationAdd)
        {
            _entries.Add(locationAdd);
        }
    }
}

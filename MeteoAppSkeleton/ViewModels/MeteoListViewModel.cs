using System.Collections.ObjectModel;
using MeteoAppSkeleton.Models;

namespace MeteoAppSkeleton.ViewModels
{
    public class MeteoListViewModel : BaseViewModel
    {
        ObservableCollection<Entry> _entries;

        public ObservableCollection<Entry> Entries
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
            Entries = new ObservableCollection<Entry>();

            for (var i = 0; i < 10; i++)
            {
                var e = new Entry
                {
                    ID = i,
                    Name = "Entry " + i
                };

                Entries.Add(e);
            }
        }
    }
}
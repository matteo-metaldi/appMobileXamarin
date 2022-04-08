namespace MeteoApp
{
    public class MeteoItemViewModel : BaseViewModel
    {
        Entry _entry;

        public Entry Entry
        {
            get { return _entry;  }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

        public MeteoItemViewModel(Entry entry)
        {
            Entry = entry;
        }
    }
}
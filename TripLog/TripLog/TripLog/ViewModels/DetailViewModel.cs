using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.ViewModels;
using TripLog.Models;
using TripLog.Service;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel<TripLogEntry>
    {
        //public DetailViewModel(TripLogEntry entry)
        //{
        //    Entry = entry;
        //}

        public DetailViewModel() 
        { }

        public DetailViewModel(INavService navService)
        { }

        public override async Task Init(TripLogEntry logEntry)
        {
           Entry = logEntry;
        }

        TripLogEntry _entry;

        public TripLogEntry Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }
    }
}

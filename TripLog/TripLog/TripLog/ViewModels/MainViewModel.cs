using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TripLog.Models;
using TripLog.Service;
using Xamarin.Forms;
using System.Threading;
using TripLog.ViewModels;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // protected INavService NavService { get; private set; }
        Command<TripLogEntry> _viewCommand;
      
        public Command<TripLogEntry>
            ViewCommand {
            get { return _viewCommand ?? (_viewCommand = new Command<TripLogEntry>(async(entry) => await ExecuteViewCommand(entry))); } }




        async Task ExecuteViewCommand(TripLogEntry entry)
        {
            await NavService.NavigateTo<DetailViewModel, TripLogEntry>(entry);
        }

        ObservableCollection<TripLogEntry> _logEntries;

        public ObservableCollection<TripLogEntry> LogEntries
        {
            get { return _logEntries; }
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavService navService) : base()
        {
            LogEntries = new ObservableCollection<TripLogEntry>();

            //LogEntries.Add(new
            //    TripLogEntry {
            //        Title = "Washington Monument",
            //        Notes = "Amazing!",
            //        Rating = 3,
            //        Date = new DateTime(2015, 2, 5),
            //        Latitude = 38.8895,
            //        Longitude = -77.0352
            //});

            //LogEntries.Add(new
            //    TripLogEntry {
            //        Title = "Statue of Liberty",
            //        Notes = "Inspiring",
            //        Rating = 4,
            //        Date = new DateTime(2015, 4, 13),
            //        Latitude = 40.6892,
            //        Longitude = -74.0444
            //});

            //LogEntries.Add(new
            //    TripLogEntry {
            //        Title = "Golden Gate Bridge",
            //        Notes = "Foggy, but beutiful.",
            //        Rating = 5,
            //        Date = new DateTime(2015, 4, 26),
            //        Latitude = 37.8268,
            //        Longitude = -122.4798
            //});
        }

        public override async Task Init()
        {
            await LoadEntries();
        }

        async Task LoadEntries()
        {
            LogEntries.Clear();

            await Task.Factory.StartNew(() =>
            {
            LogEntries.Add(new
                TripLogEntry
                {
                    Title = "Washington Monument",
                    Notes = "Amazing!",
                    Rating = 3,
                    Date = new DateTime(2015, 2, 5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                });

            LogEntries.Add(new
                TripLogEntry
                {
                    Title = "Statue of Lberty",
                    Notes = "Inspiring",
                    Rating = 4,
                    Date = new DateTime(2015, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                });

            LogEntries.Add(new
                TripLogEntry
                {
                     Title = "Golden Gate Bridge",
                     Notes = "Foggy, but beutiful",
                     Rating = 5,
                     Date = new DateTime(2015, 4, 26),
                     Latitude = 37.8268,
                     Longitude = -122.4798
                });               
            });
        }
    }
}

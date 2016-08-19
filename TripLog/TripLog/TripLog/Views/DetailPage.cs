using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using TripLog.Models;
using TripLog.Service;
using TripLog.ViewModels;

namespace TripLog.Views
{
    public class DetailPage : ContentPage
    {
        DetailViewModel _vm
        {
            get { return BindingContext as DetailViewModel; }
        }

        readonly Map _map;

        private void UpdateMap()
        {
            if (_vm.Entry == null)
                return;


            _map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(_vm.Entry.Latitude, _vm.Entry.Longitude), Distance.FromMiles(.5)));

            _map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                //  Label = entry.Title,
                Position = new Position(_vm.Entry.Latitude, _vm.Entry.Longitude)
            }
            );
        }

        public DetailPage()
        {
            BindingContextChanged += (sender, args) => {
                    if (_vm == null) return;

                     _vm.PropertyChanged += (s, e) =>
                      {
                        if (e.PropertyName == "Entry")
                        UpdateMap();
                      };
            };


            BindingContext = new DetailViewModel(DependencyService.Get<INavService>());

            Title = "Entry Details";

            var mainLayout = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition
                    {
                        Height = new GridLength (4, GridUnitType.Star)
                    },
                    new RowDefinition
                    {
                        Height = GridLength.Auto
                    },
                    new RowDefinition
                    {
                         Height = new GridLength(1, GridUnitType.Star)
                    }
                }
            };


            // var map = new Map();
            _map = new Map();

            //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(_vm.Entry.Latitude, _vm.Entry.Longitude), Distance.FromMiles(.5)));

            //map.Pins.Add(new Pin
            //{
            //    Type = PinType.Place,
            //  //  Label = entry.Title,
            //    Position = new Position(_vm.Entry.Latitude, _vm.Entry.Longitude)
            //}
            //);

            var title = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };

            // title.Text = entry.Title;
            title.SetBinding(Label.TextProperty, "Entry.Title");

            var date = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };

            //date.Text = entry.Date.ToString("M");
            date.SetBinding(Label.TextProperty, "Entry.Date", stringFormat: "{0:M}");

            var rating = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };

            // rating.Text = $"{entry.Rating} star rating";
            rating.SetBinding(Label.TextProperty, "Entry.Rating", stringFormat: "{0} star rating");

            var notes = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };

            // notes.Text = entry.Notes;
            notes.SetBinding(Label.TextProperty, "Entry.Notes");

            var details = new StackLayout
            {
                Padding = 10,
                Children =
                {
                    title, date, rating, notes
                }

            };

            var detailsBg = new BoxView
            {
               // BackgroundColor = Color.White,
               // Opacity = .8
            };

            mainLayout.Children.Add(_map);
            mainLayout.Children.Add(detailsBg, 0, 1);
            mainLayout.Children.Add(details, 0, 1);

            Grid.SetRowSpan(_map, 3);

            Content = mainLayout;
            //Content = new StackLayout
            //{
            //    Children = {
            //        new Label { Text = "Hello ContentPage" }
            //    }
            //};
        }
    }
}

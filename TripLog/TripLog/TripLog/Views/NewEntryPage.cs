using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TripLog.ViewModels;

using Xamarin.Forms;

namespace TripLog.Views
{
    public class NewEntryPage : ContentPage
    {
        public NewEntryPage()
        {

            BindingContext = new NewEntryViewModel(DependencyService.Get<INavigation>());

            Title = "New Entry";

            var title = new EntryCell
            {
                Label = "Title"
            };

            title.SetBinding(EntryCell.TextProperty, "Title", BindingMode.TwoWay);

            // Form fields
            //var title = new EntryCell
            //{
            //    Label = "Title"
            //};

            var latitude = new EntryCell
            {
                Label = "Latitude",
                Keyboard = Keyboard.Numeric
            };

            latitude.SetBinding(EntryCell.TextProperty, "Latitude", BindingMode.TwoWay);
            //var latitude = new EntryCell
            //{
            //    Label = "Latitude",
            //    Keyboard = Keyboard.Numeric
            //};

            var longitude = new EntryCell
            {
                Label = "Longitude",
                Keyboard = Keyboard.Numeric
            };

            longitude.SetBinding(EntryCell.TextProperty, "Longitude", BindingMode.TwoWay);
            //var longitude = new EntryCell
            //{
            //    Label = "Longitude",
            //    Keyboard = Keyboard.Numeric
            //};

            var date = new EntryCell
            {
                Label = "Date"
            };

            date.SetBinding(EntryCell.TextProperty, "Date", BindingMode.TwoWay, stringFormat: "{0:d}");
            //var date = new EntryCell
            //{
            //    Label = "Date"
            //};

            var rating = new EntryCell
            {
                Label = "Rating",
                Keyboard = Keyboard.Numeric
            };

            //var rating = new EntryCell
            //{
            //    Label = "Rating",
            //    Keyboard = Keyboard.Numeric
            //};

            var notes = new EntryCell
            {
                Label = "Notes"
            };

            notes.SetBinding(EntryCell.TextProperty, "Notes", BindingMode.TwoWay);

            //var notes = new EntryCell
            //{
            //    Label = "Notes"
            //};

            var entryForm = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        title,
                        latitude,
                        longitude,
                        date,
                        rating,
                        notes
                    }
                }
            };

            var save = new ToolbarItem
            {
                Text = "Save"
            };

            save.SetBinding(ToolbarItem.CommandProperty, "SaveCommand");

            ToolbarItems.Add(save);

            Content = entryForm;

            
            //Content = new StackLayout
            //{
            //    Children = {
            //        new Label { Text = "Hello ContentPage" }
            //    }
            //};
        }
    }
}

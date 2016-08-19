using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TripLog
{
    public class NewEntryPage : ContentPage
    {
        public NewEntryPage()
        {
            Title = "New Entry";

            // Form fields
            var title = new EntryCell
            {
                Label = "Title"
            };

            var latitude = new EntryCell
            {
                Label = "Latitude",
                Keyboard = Keyboard.Numeric
            };

            var longitude = new EntryCell
            {
                Label = "Longitude",
                Keyboard = Keyboard.Numeric
            };

            var date = new EntryCell
            {
                Label = "Date"
            };

            var rating = new EntryCell
            {
                Label = "Rating",
                Keyboard = Keyboard.Numeric
            };

            var notes = new EntryCell
            {
                Label = "Notes"
            };

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testXamarin.Store;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskSelectionPage : ContentPage
    {
        public TaskSelectionPage()
        {
            Context.UpdateTimeEntries();
            InitializeComponent();
            myListView.ItemsSource = Context.TimeEntries.Select(t=>t.description).Distinct();

        }

        private async void myListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (((string)myListView.SelectedItem) == "New")
            //{
            //    await Navigation.PushAsync(new AddNewTask());
            //}
            //else
            //{
            await Context.RestApi.StartTimeEntry(
                new TogglRestApi.Models.StartTimeEntry()
                    {
                        created_with = "JakubaApplication",
                        description = (string)myListView.SelectedItem,
                        pid = Context.TimeEntries.First(t => t.description == (string)myListView.SelectedItem).pid
                    });
            
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskSelectionPage : ContentPage
    {
        private DateTime _dateTime;
        public TaskSelectionPage()
        {
            InitializeComponent();
            _dateTime = DateTime.Now;
            myListView.ItemsSource = new List<string>() { "New", "Blank", "Last" } ;

        }

        private async void myListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((string)myListView.SelectedItem) == "New")
            {
                await Navigation.PushAsync(new AddNewTask(_dateTime));
            }
            else
            {

            }
        }

    }
}
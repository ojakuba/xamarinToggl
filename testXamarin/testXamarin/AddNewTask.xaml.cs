using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testXamarin.Store;
using TogglRestApi.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewTask : ContentPage
	{
        private DateTime _dateTime;
        
        public AddNewTask (DateTime dateTime)
		{
            _dateTime = dateTime;
            Context.ReloadWorkspaces();
            BindingContext = Context.ActualRunningTask;
			InitializeComponent ();
        }

        private async void newTask_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCell = (ViewCell)newTask.SelectedItem;
            switch (selectedCell.AutomationId)
            {
                case "projectCell":
                    await Navigation.PushAsync(new ProjectSelection(this));
                    break;
            }
        }
    }
}
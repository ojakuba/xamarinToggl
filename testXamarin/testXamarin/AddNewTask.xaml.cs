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
            Context.ActualRunningTask = new Models.TaskPresentationLayout();
            Context.ActualRunningTask.ProjectName = "test";
            BindingContext = Context.ActualRunningTask;

            //var tapGestureRecognizerProjectView = new TapGestureRecognizer();
            //tapGestureRecognizerProjectView.Tapped += (s, e) => {
            //    Navigation.PushAsync(new ProjectSelection(this));
            //};


            InitializeComponent ();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProjectSelection(this));
        }
    }
}
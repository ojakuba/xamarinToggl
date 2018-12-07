using System;
using System.Linq;
using testXamarin.Store;
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
            Context.ReloadProjects();
            Context.ActualRunningTask = new Models.TaskPresentationLayout();
            Context.ActualRunningTask.ProjectName = Context.Projects.FirstOrDefault().name;
            BindingContext = Context.ActualRunningTask;
            
            InitializeComponent ();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProjectSelection(this));
        }
    }
}
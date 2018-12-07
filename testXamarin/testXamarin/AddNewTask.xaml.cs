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
            Context.ActualRunningTask.WorkspaceName = Context.Workspaces.FirstOrDefault(w=>w.id == Context.UserData.default_wid).name;
            BindingContext = Context.ActualRunningTask;
            
            InitializeComponent ();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProjectSelection(this));
        }

        private async void okBtn_Clicked(object sender, EventArgs e)
        {
            var pid = Context.Projects.First(p => p.name == Context.ActualRunningTask.ProjectName).id;
            await Context.RestApi.StartTimeEntry(new TogglRestApi.Models.StartTimeEntry() { created_with = "JakubaProject", description = taskDescription.Text, pid = pid });
            await Navigation.PopToRootAsync();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkspaceSelection());
        }

        private void taskDescription_Focused(object sender, FocusEventArgs e)
        {
            taskDescription.Text = "";
        }
    }
}
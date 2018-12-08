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
        public AddNewTask ()
		{
            Context.UpdateWorkspaces();
            Context.UpdateProjects();
            Context.SelectedTaskData = new Models.TaskPresentationLayout();
            Context.SelectedTaskData.ProjectName = Context.Projects.FirstOrDefault().name;
            Context.SelectedTaskData.WorkspaceName = Context.Workspaces.FirstOrDefault(w=>w.id == Context.UserData.default_wid).name;
            BindingContext = Context.SelectedTaskData;
            
            InitializeComponent ();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProjectSelection(this));
        }

        private async void okBtn_Clicked(object sender, EventArgs e)
        {
            var pid = Context.Projects.First(p => p.name == Context.SelectedTaskData.ProjectName).id;
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
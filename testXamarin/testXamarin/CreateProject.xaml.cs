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
	public partial class CreateProject : ContentPage
	{
		public CreateProject ()
		{
			InitializeComponent ();
            Context.SelectedTaskData.WorkspaceName = Context.Workspaces.FirstOrDefault(w=>w.id == Context.UserData.default_wid).name;
            BindingContext = Context.SelectedTaskData;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkspaceSelection());
        }
        
        private void projectName_Focused(object sender, FocusEventArgs e)
        {
            projectName.Text = "";
            projectName.Focus();
        }

        private void projectName_Unfocused(object sender, FocusEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(projectName.Text))
            {
                projectName.Text = "Project name";
                okBtn.IsEnabled = false;
            }
            else
            {
                okBtn.IsEnabled = true;

            }
        }

        private async void okBtn_Clicked(object sender, EventArgs e)
        {
            if (okBtn.IsEnabled)
            {
                var wid = Context.Workspaces.FirstOrDefault(w => w.name == Context.SelectedTaskData.WorkspaceName).id;
                await Context.RestApi.CreateProject(projectName.Text, wid);
                Context.UpdateWorkspaces();
                Context.UpdateProjects();

                Context.SelectedTaskData.ProjectName = projectName.Text;
                await Navigation.PopAsync();
            }
        }
    }
}
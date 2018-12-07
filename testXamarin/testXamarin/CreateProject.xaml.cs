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
            BindingContext = Context.ActualRunningTask;
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
                await Context.RestApi.CreateProject(new TogglRestApi.Models.ProjectToggl() { name = projectName.Text});//, wid = Context.ActualRunningTask.wid
                await Navigation.PopAsync();
            }
        }
    }
}
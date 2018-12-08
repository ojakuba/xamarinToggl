using System.Linq;
using testXamarin.Store;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WorkspaceSelection : ContentPage
	{
		public WorkspaceSelection ()
		{
			InitializeComponent ();
            workspaceList.ItemsSource = Context.Workspaces.Select(w => w.name).ToList();
		}

        private void workspaceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Context.ActualRunningTaskData.WorkspaceName = (string)workspaceList.SelectedItem;
            Navigation.RemovePage(this);
        }
    }
}
using System.Linq;
using testXamarin.Store;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProjectSelection : ContentPage
	{
        private ContentPage _parent;
		public ProjectSelection (ContentPage parent)
		{
            _parent = parent;
            InitializeComponent();
            var a = Context.Projects.Select(e => e.name).ToList();
            projectList.ItemsSource = a;
		}

        private void projectList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Context.ActualRunningTask.ProjectName = (string)projectList.SelectedItem;
            Context.ActualRunningTask.pid = Context.Projects.FirstOrDefault(p => p.name == Context.ActualRunningTask.ProjectName).id;
            Navigation.PopAsync();
        }
    }
}
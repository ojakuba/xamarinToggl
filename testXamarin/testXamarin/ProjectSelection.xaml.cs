using System.Collections.Generic;
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
        public ProjectSelection(ContentPage parent)
        {
            _parent = parent;
            InitializeComponent();
            var a = new List<string>() { "New Project" };
            a.AddRange(Context.Projects.Select(e => e.name));

            projectList.ItemsSource = a;
        }

        private async void projectList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((string)projectList.SelectedItem) == "New Project")
            {
                 await Navigation.PushAsync(new CreateProject());
            }
            else
            {
                Context.SelectedTaskData.ProjectName = (string)projectList.SelectedItem;
                //Context.ActualRunningTask.pid = Context.Projects.FirstOrDefault(p => p.name == Context.ActualRunningTask.ProjectName).id;
            }
            Navigation.RemovePage(this);
        }
    }
}
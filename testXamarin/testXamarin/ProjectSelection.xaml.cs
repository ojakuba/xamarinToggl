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
	public partial class ProjectSelection : ContentPage
	{
        private ContentPage _parent;
		public ProjectSelection (ContentPage parent)
		{
            _parent = parent;
            
            BindingContext = Context.Projects;
            InitializeComponent();
		}

        private void projectList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            Navigation.PopAsync();
        }
    }
}
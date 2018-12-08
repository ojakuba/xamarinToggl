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
	public partial class Stopwatch : ContentPage
	{
		public Stopwatch ()
		{
            Context.UpdateRunningTask();
            InitializeComponent();
            BindingContext = Context.SelectedTaskData;
		}

        private async void Start_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskSelectionPage());
        }

        private async void Stop_Clicked(object sender, EventArgs e)
        {
            await Context.RestApi.StopTimeEntry(Context.RunningTask.id);
            Context.SelectedTaskData.Reset();
        }
    }
}
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
            InitializeComponent();
            BindingContext = Context.RunningTask;
            UpdateRunningTask();
		}

        private async void Start_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskSelectionPage());
        }

        private async void Stop_Clicked(object sender, EventArgs e)
        {
            await Context.RestApi.StopTimeEntry(Context.RunningTask.id);
            UpdateRunningTask();
        }
        private void UpdateRunningTask()
        {
            Context.UpdateRunningTask().Wait();
            stopBtn.IsEnabled = Context.RunningTask != null;
        }
    }
}
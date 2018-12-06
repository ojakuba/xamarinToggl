using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stopwatch : ContentPage
	{
		public Stopwatch ()
		{
			InitializeComponent ();
		}

        private async void Start_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskSelectionPage());
        }

        private void Stop_Clicked(object sender, EventArgs e)
        {

        }
    }
}
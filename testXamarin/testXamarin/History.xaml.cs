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
	public partial class History : ContentPage
	{
		public History ()
		{
            this.Appearing += (o, e) => { Context.UpdateHistory(); };
            Context.UpdateHistory();
            InitializeComponent ();
            listView.ItemsSource = Context.History;
            listView.HasUnevenRows = true;
		}
	}
}
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
            Context.UpdateHistory();
            InitializeComponent ();
            //BindingContext = Context.History;
            listView.ItemsSource = Context.History;
            // listView.RowHeight = 
            listView.HasUnevenRows = true;
		}
	}
}